-- Table: public.messages

-- DROP TABLE public.messages;

CREATE TABLE public.messages
(
    greeting character varying COLLATE pg_catalog."default",
    target character varying COLLATE pg_catalog."default"
)

TABLESPACE pg_default;

ALTER TABLE public.messages
    OWNER to "user";
	
INSERT INTO public.messages (greeting, target) VALUES ('Hello', 'World');