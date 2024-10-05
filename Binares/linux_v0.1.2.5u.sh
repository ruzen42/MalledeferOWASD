#!/bin/sh
echo -ne '\033c\033]0;OWASD\a'
base_path="$(dirname "$(realpath "$0")")"
"$base_path/linux_v0.1.2.5u.x86_64" "$@"
