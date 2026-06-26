{
  lib,
  writeShellApplication,
  dotnet-sdk_10,
  systemd,
  libusb1,
}:

(writeShellApplication {
  name = "infract";
  runtimeInputs = [ dotnet-sdk_10 ];
  text = ''
    export DOTNET_CLI_TELEMETRY_OPTOUT=1
    export DOTNET_NOLOGO=1
    export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
    export LD_LIBRARY_PATH="${
      lib.makeLibraryPath [
        systemd
        libusb1
      ]
    }:''${LD_LIBRARY_PATH:-}"

    cache_dir="''${XDG_CACHE_HOME:-''${HOME:-/tmp}/.cache}/infract-dotnet"
    mkdir -p "$cache_dir/bin" "$cache_dir/obj"
    exec dotnet run \
      --project ${./.}/InFract/InFract.csproj \
      --configuration Release \
      --property:BaseIntermediateOutputPath="$cache_dir/obj/" \
      --property:BaseOutputPath="$cache_dir/bin/" \
      -- "$@"
  '';
}).overrideAttrs
  (old: {
    meta = {
      description = "Input refractor for exposing proprietary controller features as virtual gamepads";
      homepage = "https://github.com/NaokoAF/InFract";
      license = lib.licenses.mit;
      mainProgram = "infract";
      platforms = lib.platforms.linux;
    };
  })
