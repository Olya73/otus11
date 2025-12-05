FROM liquibase/liquibase:5.0.1

ENV POSTGRESQL_JDBC_VERSION=42.7.2

COPY ./postgresql-${POSTGRESQL_JDBC_VERSION}.jar /liquibase/lib/

WORKDIR /liquibase

ENTRYPOINT ["liquibase"]