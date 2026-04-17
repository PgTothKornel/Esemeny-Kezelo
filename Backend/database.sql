DROP DATABASE IF EXISTS school_events;
CREATE DATABASE school_events CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE school_events;


CREATE TABLE users (
    id BIGINT PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    admin_privileges BOOLEAN NOT NULL DEFAULT FALSE
);

CREATE TABLE categories (
    id BIGINT PRIMARY KEY AUTO_INCREMENT,
    category VARCHAR(255) NOT NULL
);

CREATE TABLE locations (
    id BIGINT PRIMARY KEY AUTO_INCREMENT,
    location VARCHAR(255) NOT NULL
);

CREATE TABLE events (
    id BIGINT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    date DATETIME NOT NULL,
    category_id BIGINT,
    location_id BIGINT,
    description VARCHAR(1000),
    created_by_id BIGINT,
    created_date DATETIME NOT NULL,
    FOREIGN KEY (category_id) REFERENCES categories(id) ON DELETE SET NULL,
    FOREIGN KEY (location_id) REFERENCES locations(id) ON DELETE SET NULL,
    FOREIGN KEY (created_by_id) REFERENCES users(id) ON DELETE CASCADE
);

CREATE TABLE participants (
    id BIGINT PRIMARY KEY AUTO_INCREMENT,
    participant_id BIGINT NOT NULL,
    event_id BIGINT NOT NULL,
    FOREIGN KEY (participant_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (event_id) REFERENCES events(id) ON DELETE CASCADE
);


INSERT INTO users (id, username, password, admin_privileges) VALUES
(1, 'rokolya_csaba', '$2a$12$O6MwSAdAqfPGvzdC0ZZZLuiQXRdWjQU8UGljOFkgjmjRiIwLLzA7y', TRUE), --password
(2, 'pasztor_zoltan', '$2a$12$jCzhELJMcLKIUIR6vHqxyuJuR4GXtiq5Uv.TzRI6yo.dvVx1hlwfy', TRUE), --pza_gnd
(3, 'kiss_gabor', '$2a$12$PxxnINJtYVrw826cHrPSNu6fAA3HJXFmcw2.PGPrNS05PBlOF8sC.', TRUE), --kgi123
(4, 'pozsar_robert', '$2a$12$nhETBVgxvdcKeWddb1C2feII27kgQOg6rqYNBAzxEGbgEb7ryzGEm', FALSE), --robi0621
(5, 'hodi_agnes', '$2a$12$nM6qoCBhQcSuptedAKemFe3oWqWJIJmYby2lbG3YD7XByAMjK/JQi', FALSE), --olddmeg
(6, 'simo_zsuzsanna', '$2a$12$J9IB21z9AIrJFKL6LyeGuudJHXg65txaaPJPK5HCPp0SaszJwgvA2', FALSE), --random
(7, 'kocsis_noel', '$2a$12$kD48QRdZH2hlBuwUbwBc3e.QWVDw0FcsSRqzqXxzb1vNgd4IfLaQy', FALSE), --kocsi
(8, 'toth_kornel', '$2a$12$oe2fK1z7pIwNxc3MA5qmJ.Ak/2vnb36UjN7jMzfi6ZrFQh92x99M6', FALSE), --igen123
(9, 'tapai-fero_marcell', '$2a$12$UwnpB6KQi9k3Mc4fht4xtuH/GRW0ei1DjhL6BIgdme71.E7JXmfnC', FALSE), --nemtom123
(10, 'gyongyosi_csaba', '$2a$12$PdEzxzvnHrR.klvHwzWXQOReCZhpoqVqCyUbipYb68IKc1LN.faMG', FALSE), --silencione
(10, 'admin', '$2a$12$oa0eB5sMBRukkuaf1BXFN./LkCcSGcOcbHs5GQw62B4BKQtttRhtG', TRUE); --admin

INSERT INTO categories (id, category) VALUES
(1, 'Sport'),
(2, 'Tanulmányi'),
(3, 'Kulturális'),
(4, 'Szórakozás'),
(5, 'Közösségi');

INSERT INTO locations (id, location) VALUES
(1, 'Tornaterem'),
(2, '7. terem'),
(3, 'Kosárlabda pálya'),
(4, 'Könyvtár'),
(5, 'Ebédlő');

INSERT INTO events (id, name, date, category_id, location_id, description, created_by_id, created_date) VALUES
(1, 'Tavaszi Focibajnokság', '2026-05-10 14:00:00', 1, 3, 'Osztályok közötti tavaszi labdarúgó kupa.', 1, '2026-04-10 08:30:00'),
(2, 'Iskolai Matematika Verseny', '2026-04-25 10:00:00', 2, 2, 'Házibajnokság a legjobb matematikusoknak.', 2, '2026-04-05 11:15:00'),
(3, 'Tavaszi Koncert', '2026-05-15 18:00:00', 3, 2, 'Az iskolai énekkar és zenekar fellépése.', 3, '2026-04-12 09:45:00'),
(4, 'Társasjáték Délután', '2026-04-20 15:00:00', 4, 4, 'Hozd el a kedvenc társasodat és játsszunk együtt!', 5, '2026-04-15 14:20:00'),
(5, 'Diákönkormányzati Gyűlés', '2026-04-22 14:30:00', 5, 5, 'A DÖK havi rendes megbeszélése az elkövetkező programokról.', 1, '2026-04-16 10:00:00');

INSERT INTO participants (id, participant_id, event_id) VALUES
(1, 2, 1),
(2, 4, 1),
(3, 7, 1),
(4, 1, 2),
(5, 3, 2),
(6, 8, 3),
(7, 9, 3),
(8, 10, 3),
(9, 5, 4),
(10, 6, 4),
(11, 2, 5),
(12, 3, 5);