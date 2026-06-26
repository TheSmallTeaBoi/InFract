{
  description = "Nix package, app, and NixOS module for InFract";

  inputs.nixpkgs.url = "github:NixOS/nixpkgs/nixos-unstable";

  outputs =
    { self, nixpkgs }:
    let
      lib = nixpkgs.lib;
      systems = [
        "x86_64-linux"
        "aarch64-linux"
      ];
      forAllSystems = lib.genAttrs systems;
    in
    {
      packages = forAllSystems (
        system:
        let
          pkgs = import nixpkgs { inherit system; };
        in
        {
          default = pkgs.callPackage ./package.nix { };
          infract = self.packages.${system}.default;
        }
      );

      apps = forAllSystems (system: {
        default = {
          type = "app";
          program = lib.getExe self.packages.${system}.default;
        };
        infract = self.apps.${system}.default;
      });

      devShells = forAllSystems (
        system:
        let
          pkgs = import nixpkgs { inherit system; };
        in
        {
          default = pkgs.mkShell {
            packages = [ pkgs.dotnet-sdk_10 ];
          };
        }
      );

      nixosModules.default =
        { config, pkgs, ... }:
        let
          cfg = config.services.infract;
        in
        {
          options.services.infract = {
            enable = lib.mkEnableOption "InFract controller refractor";

            package = lib.mkOption {
              type = lib.types.package;
              default = self.packages.${pkgs.stdenv.hostPlatform.system}.default;
              defaultText = lib.literalExpression "inputs.infract.packages.\${pkgs.system}.default";
              description = "InFract package to use.";
            };

            user = lib.mkOption {
              type = lib.types.str;
              default = "infract";
              description = "User account that runs the InFract service.";
            };

            group = lib.mkOption {
              type = lib.types.str;
              default = "input";
              description = "Group account that runs the InFract service.";
            };

            environment = lib.mkOption {
              type = lib.types.attrsOf lib.types.str;
              default = { };
              example = {
                INFRACT_CONVERTER = "SINPUT";
              };
              description = "Environment variables passed to InFract.";
            };
          };

          config = lib.mkIf cfg.enable {
            # Required for virtual controller creation
            boot.kernelModules = [
              "uinput"
              "uhid"
            ];

            # Ensure the group exists (NixOS usually has 'input' by default,
            # but we ensure it's available)
            users.groups.input = { };

            users.users = lib.mkIf (cfg.user == "infract") {
              infract = {
                isSystemUser = true;
                group = cfg.group;
                extraGroups = [ "input" ];
                home = "/var/lib/infract";
                createHome = true;
              };
            };

            services.udev.extraRules = ''
              # UHID and UINPUT access
              KERNEL=="uhid", GROUP="input", MODE="0660"
              KERNEL=="uinput", GROUP="input", MODE="0660", OPTIONS+="static_node=uinput"

              # GameSir HID access
              SUBSYSTEM=="hidraw", ATTRS{idVendor}=="3537", GROUP="input", MODE="0660", TAG+="uaccess"

              # Hide GameSir Cyclone 2 (XInput, Wired and Wireless)
              SUBSYSTEM=="usb", ATTRS{idVendor}=="3537", ATTRS{idProduct}=="1053", ATTR{bInterfaceNumber}=="00", RUN+="${pkgs.bash}/bin/sh -c 'echo -n %k > /sys/bus/usb/drivers/xpad/unbind'"
              SUBSYSTEM=="usb", ATTRS{idVendor}=="3537", ATTRS{idProduct}=="100b", ATTR{bInterfaceNumber}=="00", RUN+="${pkgs.bash}/bin/sh -c 'echo -n %k > /sys/bus/usb/drivers/xpad/unbind'"
            '';

            systemd.services.infract = {
              description = "InFract controller refractor";
              wantedBy = [ "multi-user.target" ];
              after = [
                "systemd-udevd.service"
                "network.target"
              ];

              serviceConfig = {
                ExecStart = lib.getExe cfg.package;
                Restart = "on-failure";
                User = cfg.user;
                Group = cfg.group;

                # Permissions fixes:
                # 1. Give the process the ability to act as a system admin (needed for some uinput ioctls)
                AmbientCapabilities = [ "CAP_SYS_ADMIN" ];
                CapabilityBoundingSet = [ "CAP_SYS_ADMIN" ];

                # 2. Ensure device access is allowed in the sandbox
                DeviceAllow = [
                  "/dev/uhid rw"
                  "/dev/uinput rw"
                  "char-hidraw rw"
                  "char-input rw"
                ];

                # 3. State Management
                StateDirectory = "infract";
                WorkingDirectory = "/var/lib/infract";

                # Security hardening (Allowing devices while restricting others)
                ProtectSystem = "full";
                ProtectHome = true;
                PrivateVideo = true;
                # Note: PrivateDevices must be false to access /dev/uinput and /dev/uhid
                PrivateDevices = false;
              };

              environment = cfg.environment // {
                HOME = "/var/lib/infract";
                DOTNET_BUNDLE_EXTRACT_BASE_DIR = "/var/lib/infract/.dotnet/bundle";
              };
            };
          };
        };
    };
}
