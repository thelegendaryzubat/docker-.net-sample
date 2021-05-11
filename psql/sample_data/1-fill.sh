psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL
    create schema if not exists $SCHEMA;
    create table $SCHEMA.weather_forecasts (
        Id           integer PRIMARY KEY,
        Date         TIMESTAMP NOT NULL,
        TemperatureC integer NOT NULL
    );
    GRANT ALL PRIVILEGES ON DATABASE dckr_q TO dckr_q;
EOSQL

file="/docker-entrypoint-initdb.d/2-sample_data.sql"

echo "Restoring DB using $file"
pg_restore -U $POSTGRES_USER --dbname=$POSTGRES_DB --verbose --single-transaction < "$file" || exit 1