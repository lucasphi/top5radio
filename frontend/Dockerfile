FROM node:alpine AS builder

WORKDIR /app

COPY . .

RUN npm install && \
    npm run build

FROM nginx:alpine

COPY --from=builder /app/dist/* /usr/share/nginx/html/

RUN printf "server {\n\t	root /usr/share/nginx/html;\n\n\n\t	location ~ /*/\.(jpeg,jpg,png,svg) {\n\t\t		root /usr/share/nginx/html/assets/img/;\n\t	}\n\n\n\t	location /api/ {\n\t\t		proxy_pass http://api/;\n\t	}\n\n\n \t   location /adm/ {\n\t\t		proxy_pass http://admin/;\n\t	}\n\n\n}" > /etc/nginx/conf.d/default.conf

CMD ["nginx", "-g", "daemon off;"]