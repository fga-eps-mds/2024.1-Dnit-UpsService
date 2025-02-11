#!/bin/bash

set -x
WORKDIR=$(pwd)

python3 -m venv .venv
source $WORKDIR/.venv/bin/activate

pip install dnit_updater --upgrade
pip install uvicorn

cat > /etc/systemd/system/dnit-deploy.service <<EOF
[Unit]
Description = Deploy Dnit Service

[Service]
WorkingDirectory=$WORKDIR
EnvironmentFile=/etc/dnit-deploy/env
ExecStart=$WORKDIR/.venv/bin/python -m uvicorn dnit_updater:app --host 0.0.0.0 --port 30001
Restart=on-failure

[Install]
WantedBy=multi-user.target
EOF

cat > /etc/systemd/system/upservice.service <<EOF
[Unit]
Description = Ups Service

[Service]
WorkingDirectory=$WORKDIR
ExecStart=$WORKDIR/start.sh
User=eps
Restart=on-failure
EnvironmentFile=/etc/dnit-deploy/env

[Install]
WantedBy=multi-user.target
EOF

systemctl daemon-reload
systemctl enable dnit-deploy.service --now
systemctl enable upservice.service --now