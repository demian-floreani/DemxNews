FROM nginx:latest

COPY nginx.conf /etc/nginx/nginx.conf

COPY fullchain.pem /etc/letsencrypt/live/renegadenews.net/fullchain.pem
COPY privkey.pem /etc/letsencrypt/live/renegadenews.net/privkey.pem
COPY dhparam-2048.pem /etc/ssl/certs/dhparam-2048.pem
