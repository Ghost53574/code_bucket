#!/bin/bash
# WT7 Updater
# Initialization script for ease of use
# Douglas Berdeaux - WeakNetLabs@Gmail.com
rm -rf /tmp/wt7-updater # remove cruft
cd /tmp && git clone https://github.com/weaknetlabs/wt7-updater && cd wt7-updater
chmod +x update-wt7.sh && ./update-wt7.sh
