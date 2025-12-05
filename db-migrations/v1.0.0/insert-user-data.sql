-- liquibase formatted sql

-- changeset oa.tikhomirova:insert-user-data
INSERT INTO public.users (user_name, first_name, last_name, email, phone)
VALUES ('admin', 'admin', 'admin', 'olya.drjd73@gmail.com', '+79805308700');
