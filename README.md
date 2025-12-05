# Для запуска приложения из текущей папки репозитория
kubectl apply -f .\dev-config\postgres-secret.yaml
kubectl apply -f .\dev-config\job-secret.yaml
kubectl apply -f .\dev-config\dp-secret.yaml

kubectl apply -f .\deploy\pvc.yaml
helm install my-pg oci://registry-1.docker.io/bitnamicharts/postgresql -f .\deploy\override.yaml

kubectl create configmap liquibase-changelog-master --from-file=db-migrations\db.changelog-master.yaml
kubectl create configmap liquibase-changelogv1.0.0 --from-file=db-migrations\v1.0.0
kubectl apply -f .\deploy\job-migration.yaml

kubectl apply -f .\deploy\deployment.yaml
kubectl apply -f .\deploy\service.yaml
kubectl apply -f .\deploy\ingress.yaml

# Для проверки работы сервиса использовать
curl [http://arch.homework/health](http://arch.homework/health)
curl [http://arch.homework/otusapp/aeugene/health](http://arch.homework/otusapp/aeugene/health)

newman run crud.json -e dev.env.json
