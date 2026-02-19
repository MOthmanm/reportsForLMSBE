-- Enable the extension
CREATE EXTENSION IF NOT EXISTS postgres_fdw;

-- Create the server connection to the 'postgres' database
-- NOTE: Update host/port/dbname if different
DROP SERVER IF EXISTS hrcycles_server CASCADE;
CREATE SERVER hrcycles_server
    FOREIGN DATA WRAPPER postgres_fdw
    OPTIONS (host 'localhost', port '5432', dbname 'postgres');

-- Create user mapping for the current user (postgres)
-- NOTE: Update password if different from '123'
DROP USER MAPPING IF EXISTS FOR postgres SERVER hrcycles_server;
CREATE USER MAPPING FOR postgres
    SERVER hrcycles_server
    OPTIONS (user 'postgres', password '123');

-- Create a local schema to hold the foreign tables
CREATE SCHEMA IF NOT EXISTS hrcycles;

-- Import the schema from the remote database
-- This assumes the schema in the 'postgres' DB is also named 'hrcycles'
-- If 'hrcycles' schema exists in 'postgres' DB:
IMPORT FOREIGN SCHEMA hrcycles
    FROM SERVER hrcycles_server
    INTO hrcycles;

-- OR if the tables are in the 'public' schema of the 'postgres' DB but you want them in 'hrcycles' locally:
-- IMPORT FOREIGN SCHEMA public
--     FROM SERVER hrcycles_server
--     INTO hrcycles;
