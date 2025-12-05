-- liquibase formatted sql

-- changeset oa.tikhomirova:create-table-user
CREATE TABLE IF NOT EXISTS public.users (
	id bigserial NOT NULL,
	user_name varchar NOT NULL,
	first_name varchar NOT NULL,
	last_name varchar NOT NULL,
	email varchar NOT NULL,
	phone varchar NOT NULL,
	CONSTRAINT user_pk PRIMARY KEY (id)
);

COMMENT ON TABLE public.users is 'Таблица пользователей';

COMMENT ON COLUMN public.users.id is 'Идентификатор пользователя';
COMMENT ON COLUMN public.users.user_name is 'Логин пользователя';
COMMENT ON COLUMN public.users.first_name is 'Имя пользователя';
COMMENT ON COLUMN public.users.last_name is 'Фамилия пользователя';
COMMENT ON COLUMN public.users.email is 'Электронная почта';
COMMENT ON COLUMN public.users.phone is 'Телефон';

-- changeset oa.tikhomirova:create-index-searchkey
CREATE UNIQUE INDEX IF NOT EXISTS users_user_name ON public.users (user_name);