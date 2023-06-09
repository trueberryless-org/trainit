﻿-- Delete all data

delete
from users
where true;

delete
from workouts
where true;

delete
from exercises
where true;

delete
from activities
where true;

delete
from workout_has_exercises_jt
where true;

-- Insert data

insert into users (USER_ID, USERNAME, EMAIL, PASSWORD_HASH)
VALUES (1,'Yanik', 'yanik.latzka@gmx.at', '$2a$08$e.TQRVdZdcWBndM/Iooagut2279IO8OYyIyJeGTT38I1xJD1iIJQW'),
       (2,'trueberryless', 'felix@schneider-it.at', '$2a$08$e.TQRVdZdcWBndM/Iooagut2279IO8OYyIyJeGTT38I1xJD1iIJQW'),
       (3,'Jürgen', 'j.hauptmann@htlkrems.at', '$2a$08$e.TQRVdZdcWBndM/Iooagut2279IO8OYyIyJeGTT38I1xJD1iIJQW'),
       (4,'Test', 'test@email.com', '$2a$08$e.TQRVdZdcWBndM/Iooagut2279IO8OYyIyJeGTT38I1xJD1iIJQW'),
       (5,'Paul', 'p.panhofer@htlkrems.at', '$2a$08$e.TQRVdZdcWBndM/Iooagut2279IO8OYyIyJeGTT38I1xJD1iIJQW');

insert into workouts (WORKOUT_ID, USER_ID, NAME, DESCRIPTION)
VALUES (1, 1, 'Monday', 'A full-body workout featuring exercises 1, 2, 20, 21, 47, and 48.'),                                  -- user: 1 / exercises: 1, 2, 20, 21, 47, 48
       (2, 2, 'Legs', 'A leg-focused workout featuring exercises 3, 22, 23, and 40.'),                                         -- user: 2 / exercises: 3, 22, 23, 40
       (3, 5, 'Push', 'A upper body pushing workout featuring exercises 4, 5, 24, and 50.'),                                   -- user: 5 / exercises: 4, 5, 24, 50
       (4, 5, 'Pull', 'A upper body pulling workout featuring exercises 6, 25, 26, 51, and 52.'),                              -- user: 5 / exercises: 6, 25, 26, 51, 52
       (5, 1, 'Thuesday', 'A full-body workout featuring exercises 7, 8, 20, 27, 48, and 53.'),                                -- user: 1 / exercises: 7, 8, 20, 27, 48, 53
       (6, 4, 'Workout 1', 'A workout featuring exercises 9, 28, 29, 30, 43, and 54.'),                                        -- user: 4 / exercises: 9, 28, 29, 30, 43, 54
       (7, 2, 'Arms', 'An arm-focused workout featuring exercises 10, 11, 22, 31, 40, and 55.'),                               -- user: 2 / exercises: 10, 11, 22, 31, 40, 55
       (8, 5, 'Carry', 'A workout featuring exercises 12, 32, and 33, with an emphasis on carrying or holding weight.'),       -- user: 5 / exercises: 12, 32, 33
       (9, 1, 'Wednesday', 'A full-body workout featuring exercises 13, 21, 34, and 56.'),                                     -- user: 1 / exercises: 13, 21, 34, 56
       (10, 4, 'Workout 2', 'A workout featuring exercises 9, 17, 35, 36, 54, and 57.'),                                       -- user: 4 / exercises: 9, 17, 35, 36, 54, 57
       (11, 4, 'Workout 3', 'A workout featuring exercises 14, 28, 36, and 37.'),                                              -- user: 4 / exercises: 14, 28, 36, 37
       (12, 5, 'Hold', 'A workout featuring exercises 15, 38, 39, and 58, with an emphasis on holding or carrying weight.'),   -- user: 5 / exercises: 15, 38, 39, 58
       (13, 2, 'Body', 'A full-body workout featuring exercises 3, 16, 40, 41, and 55.'),                                      -- user: 2 / exercises: 3, 16, 40, 41, 55
       (14, 4, 'Workout 4', 'A workout featuring exercises 14, 17, 18, 42, and 57.'),                                          -- user: 4 / exercises: 14, 17, 18, 42, 57
       (15, 4, 'Workout 5', 'A workout featuring exercises 19, 36, 42, 43, 44, and 54.'),                                      -- user: 4 / exercises: 19, 36, 42, 43, 44, 54
       (16, 1, 'Friday', 'A full-body workout featuring exercises 20, 34, 45, 46, and 59.');                                   -- user: 1 / exercises: 20, 34, 45, 46, 59


insert into exercises (EXERCISE_ID, NAME, MACHINE_ASSET_ID, DESCRIPTION, USER_ID)
VALUES (1,'Bench press', null, 'An exercise that involves lying on a weight bench and pressing a barbell or dumbbells upwards', 1),
       (2,'Pull-up', null, 'An exercise that involves pulling your body up to a bar using your arms', 1),
       (3,'Leg press', null, 'An exercise that involves pushing a weight plate away from your body using your legs', 2),
       (4,'Dips', null, 'An exercise that involves lowering and raising your body using your arms while holding onto parallel bars', 5),
       (5,'Chest press', null, 'An exercise that involves pressing weight plates away from your body using your chest muscles', 5),
       (6,'Pull-up', null, 'An exercise that involves pulling your body up to a bar using your arms', 5),
       (7,'Leg raises', null, 'An exercise that involves raising your legs off the ground while lying on your back', 1),
       (8,'Leg press', null, 'An exercise that involves pushing a weight plate away from your body using your legs', 1),
       (9,'Leg press', null, 'An exercise that involves pushing a weight plate away from your body using your legs', 4),
       (10,'Curl bench', null, 'An exercise that involves curling a weight upwards using your arms while lying on a bench', 2),
       (11,'Dumbbell curls', null, 'An exercise that involves curling dumbbells upwards using your arms while standing or sitting', 2),
       (12,'Dumbbell lunges', null, 'An exercise that involves lunging forward with a dumbbell in each hand', 5),
       (13,'Dips', null, 'An exercise that involves lowering and raising your body using your arms while holding onto parallel bars', 1),
       (14,'Exercise bike', null, 'An exercise that involves cycling on a stationary bike', 4),
       (15,'Plank', null, 'An exercise that involves holding your body in a straight line while resting on your forearms and toes', 5),
       (16,'Lat pull-down', null, 'An exercise that involves pulling a bar down towards your chest using your back muscles', 2),
       (17,'Water aerobics', null, 'A low-impact cardiovascular exercise performed in a pool', 4),
       (18,'Step aerobics', null, 'A cardiovascular exercise performed on a raised platform using a series of stepping and jumping movements', 4),
       (19,'Dips', null, 'An exercise that involves lowering and raising your body using your arms while holding onto parallel bars', 4),
       (20,'Rowing machine', null, 'An exercise that involves simulating the motion of rowing a boat using a machine', 1),
       (21,'Weight bench', null, 'A bench used for weight training exercises such as bench press and dumbbell flyes', 1),
       (22,'Elliptical trainer', null, 'An exercise machine that simulates running or walking without causing excessive impact on the joints', 2),
       (23,'Dumbbell squats', null, 'An exercise that involves squatting down and standing up while holding a dumbbell in each hand', 2),
       (24,'Wall push-up', null, 'An exercise that involves pushing your body away from a wall using your arms', 5),
       (25,'Curl bench', null, 'An exercise that involves curling a weight upwards using your arms while lying on a bench', 5),
       (26,'Cable pull-down', null, 'An exercise that involves pulling a cable down towards your body using a pulley system', 5),
       (27,'Step aerobics', null, 'A cardiovascular exercise performed on a raised platform using a series of stepping and jumping movements', 1),
       (28,'Cable cross', null, 'An exercise that involves pulling a cable from one side of your body to the other using a pulley system', 4),
       (29,'Leg raises', null, 'An exercise that involves raising your legs off the ground while lying on your back', 4),
       (30,'Bench press', null, 'An exercise that involves lying on a weight bench and pressing a barbell or dumbbells upwards', 4),
       (31,'Resistance bands', null, 'Elastic bands used for strength training exercises', 2),
       (32,'Dumbbell calf raises', null, 'An exercise that involves standing on your toes while holding dumbbells to strengthen your calf muscles', 5),
       (33,'Farmers Carry', null, 'An exercise that involves carrying heavy weights in each hand to strengthen your grip and core muscles', 5),
       (34,'Curl bench', null, 'An exercise that involves curling a weight upwards using your arms while lying on a bench', 1),
       (35,'Trampoline', null, 'An exercise that involves bouncing on a trampoline for cardiovascular and balance training', 4),
       (36,'Dumbbell flyes', null, 'An exercise that involves lying on a weight bench and pressing dumbbells outwards in a fly-like motion', 4),
       (37,'Dumbbell squats', null, 'An exercise that involves squatting down and standing up while holding a dumbbell in each hand', 4),
       (38,'Swiss ball exercises', null, 'Exercises performed using a large, inflatable ball to improve balance and stability', 5),
       (39,'Wall sit', null, 'An exercise that involves sitting against a wall with your legs bent at a 90 degree angle', 5),
       (40,'Treadmill', null, 'An exercise machine that simulates walking or running on a moving belt', 2),
       (41,'Cable rows', null, 'An exercise that involves pulling a cable towards your body using a pulley system to work your back muscles', 2),
       (42,'Pull-up', null, 'An exercise that involves pulling your body up to a bar using your arms', 4),
       (43,'Sit-ups', null, 'An exercise that involves sitting up from a lying position and touching your knees with your elbows', 4),
       (44,'Lat pull-down', null, 'An exercise that involves pulling a bar down towards your chest using your back muscles', 4),
       (45,'Sit-ups', null, 'An exercise that involves sitting up from a lying position and touching your knees with your elbows', 1),
       (46,'Twister', null, 'An exercise that involves twisting your body on a board to improve balance and core strength', 1),
       (47,'Cable crossover', null, 'An exercise that involves pulling a cable from one side of your body to the other using a pulley system', 1),
       (48,'Shoulder press', null, 'An exercise that involves pressing a weight upwards using your shoulders', 1),
       (49,'Twister', null, 'An exercise that involves twisting your body on a board to improve balance and core strength', 5),
       (50,'Incline bench press', null, 'An exercise that involves lying on an incline weight bench and pressing a barbell or dumbbells upwards', 5),
       (51,'Cable tricep pushdown', null, 'An exercise that involves pushing a cable down using your tricep muscles', 5),
       (52,'Rowing machine', null, 'An exercise that involves simulating the motion of rowing a boat using a machine', 5),
       (53,'Trampoline', null, 'An exercise that involves bouncing on a trampoline for cardiovascular and balance training', 1),
       (54,'Twister', null, 'An exercise that involves twisting your body on a board to improve balance and core strength', 4),
       (55,'Tricep dips', null, 'An exercise that involves lowering and raising your body using your tricep muscles while holding onto parallel bars', 2),
       (56,'Tricep press', null, 'An exercise that involves pressing a weight upwards using your tricep muscles', 1),
       (57,'Plank', null, 'An exercise that involves holding your body in a straight line while resting on your forearms and toes', 4),
       (58,'Overhead hold', null, 'An exercise that involves holding a bar overhead to improve shoulder strength and stability', 5),
       (59,'Swiss ball exercises', null, 'Exercises performed using a large, inflatable ball to improve balance and stability', 1),
       (60,'Squats', null, 'An exercise that involves squatting down and standing up', 3),
       (61,'Deadlifts', null, 'An exercise that involves lifting a weight off the ground while keeping your back straight', 3),
       (62,'Bench press', null, 'An exercise that involves lying on a weight bench and pressing a barbell or dumbbells upwards', 3),
       (63,'Lunges', null, 'An exercise that involves lunging forward with one leg', 3),
       (64,'Push-ups', null, 'An exercise that involves pushing your body off the ground using your arms', 3),
       (65,'Pull-ups', null, 'An exercise that involves pulling your body up to a bar using your arms', 3),
       (66,'Tricep dips', null, 'An exercise that involves lowering and raising your body using your tricep muscles while holding onto parallel bars', 3),
       (67,'Bicep curls', null, 'An exercise that involves curling a weight upwards using your bicep muscles', 3),
       (68,'Burpees', null, 'An exercise that involves squatting down, jumping back into a plank position, and then jumping back up and reaching your arms overhead', 3),
       (69,'Mountain climbers', null, 'An exercise that involves alternating between a plank position and bringing one knee towards your chest', 3);

insert into activities (ACTIVITY_ID, EXERCISE_ID, DATE, WEIGHT, REPETITION, `SET`)
VALUES (1, 1, '2022-12-24', 20, 10, 3),
       (2, 1, '2022-12-26', 48.25, 10, 3),
       (3, 1, '2022-12-28', 7.5, 10, 3),
       (4, 1, '2022-12-29', 17.5, 10, 3),
       (5, 2, '2022-12-24', 35, 10, 3),
       (6, 2, '2022-12-25', 22.5, 10, 3),
       (7, 2, '2022-12-26', 27.5, 10, 3),
       (8, 2, '2022-12-29', 7.5, 10, 3),
       (9, 2, '2022-12-30', 43.25, 10, 3),
       (10, 2, '2022-12-31', 52.5, 10, 3),
       (11, 3, '2022-12-24', 20, 10, 3),
       (12, 3, '2022-12-27', 2.5, 10, 3),
       (13, 3, '2022-12-28', 5, 10, 3),
       (14, 4, '2022-12-24', 17.5, 10, 3),
       (15, 4, '2022-12-25', 22.5, 10, 3),
       (16, 4, '2022-12-26', 45, 10, 3),
       (17, 4, '2022-12-30', 12.5, 10, 3),
       (18, 4, '2022-12-31', 35, 10, 3),
       (19, 5, '2022-12-26', 2.5, 10, 3),
       (20, 5, '2022-12-28', 20, 10, 3),
       (21, 5, '2022-12-29', 43.25, 10, 3),
       (22, 6, '2022-12-24', 10, 10, 3),
       (23, 6, '2022-12-25', 20, 10, 3),
       (24, 6, '2022-12-27', 57.5, 10, 3),
       (25, 6, '2022-12-29', 22.5, 10, 3),
       (26, 6, '2022-12-30', 27.5, 10, 3),
       (27, 7, '2022-12-24', 12.5, 10, 3),
       (28, 7, '2022-12-28', 35, 10, 3),
       (29, 7, '2022-12-30', 45, 10, 3),
       (30, 8, '2022-12-24', 52.5, 10, 3),
       (31, 8, '2022-12-25', 7.5, 10, 3),
       (32, 8, '2022-12-26', 20, 10, 3),
       (33, 8, '2022-12-27', 22.5, 10, 3),
       (34, 8, '2022-12-29', 5, 10, 3),
       (35, 8, '2022-12-30', 17.5, 10, 3),
       (36, 8, '2022-12-31', 11.25, 10, 3),
       (37, 9, '2022-12-25', 100, 10, 3),
       (38, 9, '2022-12-26', 43.25, 10, 3),
       (39, 9, '2022-12-27', 20, 10, 3),
       (40, 9, '2022-12-28', 35, 10, 3),
       (41, 9, '2022-12-30', 12.5, 10, 3),
       (42, 10, '2022-12-24', 22.5, 10, 3),
       (43, 10, '2022-12-25', 45, 10, 3),
       (44, 10, '2022-12-29', 27.5, 10, 3),
       (45, 11, '2022-12-26', 48.25, 10, 3),
       (46, 11, '2022-12-28', 17.5, 10, 3),
       (47, 11, '2022-12-29', 57.5, 10, 3),
       (48, 11, '2022-12-31', 20, 10, 3),
       (49, 12, '2022-12-24', 20, 10, 3),
       (50, 12, '2022-12-26', 5, 10, 3),
       (51, 13, '2022-12-25', 10, 10, 3),
       (52, 13, '2022-12-27', 60, 10, 3),
       (53, 13, '2022-12-28', 43.25, 10, 3),
       (54, 13, '2022-12-30', 63.25, 10, 3),
       (55, 13, '2022-12-31', 7.5, 10, 3),
       (56, 14, '2022-12-24', 20, 10, 3),
       (57, 14, '2022-12-25', 35, 10, 3),
       (58, 14, '2022-12-26', 11.25, 10, 3),
       (59, 14, '2022-12-29', 27.5, 10, 3),
       (60, 15, '2022-12-24', 5, 10, 3),
       (61, 15, '2022-12-27', 22.5, 10, 3),
       (62, 15, '2022-12-28', 20, 10, 3),
       (63, 15, '2022-12-29', 2.5, 10, 3),
       (64, 15, '2022-12-30', 43.25, 10, 3),
       (65, 15, '2022-12-31', 12.5, 10, 3),
       (66, 16, '2022-12-24', 12.5, 10, 3),
       (67, 16, '2022-12-25', 17.5, 10, 3),
       (68, 16, '2022-12-26', 22.5, 10, 3),
       (69, 16, '2022-12-28', 35, 10, 3),
       (70, 16, '2022-12-29', 1.25, 10, 3),
       (71, 16, '2022-12-30', 52.5, 10, 3),
       (72, 16, '2022-12-31', 20, 10, 3),
       (73, 17, '2022-12-24', 45, 10, 3),
       (74, 17, '2022-12-26', 43.25, 10, 3),
       (75, 17, '2022-12-27', 27.5, 10, 3),
       (76, 17, '2022-12-28', 7.5, 10, 3),
       (77, 18, '2022-12-25', 10, 10, 3),
       (78, 18, '2022-12-30', 22.5, 10, 3),
       (79, 18, '2022-12-31', 63.25, 10, 3),
       (80, 19, '2022-12-26', 5, 10, 3),
       (81, 19, '2022-12-27', 11.25, 10, 3),
       (82, 20, '2022-12-24', 35, 10, 3),
       (83, 20, '2022-12-25', 20, 10, 3),
       (84, 20, '2022-12-29', 17.5, 10, 3),
       (85, 21, '2022-12-24', 45, 10, 3),
       (86, 21, '2022-12-26', 43.25, 10, 3),
       (87, 22, '2022-12-25', 52.5, 10, 3),
       (88, 22, '2022-12-26', 27.5, 10, 3),
       (89, 22, '2022-12-28', 1.25, 10, 3),
       (90, 22, '2022-12-29', 2.5, 10, 3),
       (91, 23, '2022-12-24', 35, 10, 3),
       (92, 23, '2022-12-25', 100, 10, 3),
       (93, 24, '2022-12-24', 5, 10, 3),
       (94, 24, '2022-12-26', 45, 10, 3),
       (95, 24, '2022-12-29', 17.5, 10, 3),
       (96, 25, '2022-12-24', 43.25, 10, 3),
       (97, 25, '2022-12-25', 22.5, 10, 3),
       (98, 25, '2022-12-27', 7.5, 10, 3),
       (99, 25, '2022-12-29', 12.5, 10, 3),
       (100, 26, '2022-12-24', 22.5, 10, 3),
       (101, 26, '2022-12-28', 2.5, 10, 3),
       (102, 27, '2022-12-31', 27.5, 10, 3),
       (103, 28, '2022-12-25', 63.25, 10, 3),
       (104, 28, '2022-12-26', 35, 10, 3),
       (105, 28, '2022-12-30', 43.25, 10, 3),
       (106, 29, '2022-12-24', 5, 10, 3),
       (107, 29, '2022-12-31', 20, 10, 3),
       (108, 30, '2022-12-25', 57.5, 10, 3),
       (109, 30, '2022-12-28', 43.25, 10, 3),
       (110, 30, '2022-12-29', 22.5, 10, 3),
       (111, 31, '2022-12-24', 11.25, 10, 3),
       (112, 31, '2022-12-25', 22.5, 10, 3),
       (113, 32, '2022-12-27', 45, 10, 3),
       (114, 32, '2022-12-28', 52.5, 10, 3),
       (115, 33, '2022-12-26', 27.5, 10, 3),
       (116, 33, '2022-12-29', 43.25, 10, 3),
       (117, 33, '2022-12-28', 7.5, 10, 3),
       (118, 34, '2022-12-24', 35, 10, 3),
       (119, 34, '2022-12-26', 20, 10, 3),
       (120, 35, '2022-12-28', 1.25, 10, 3),
       (121, 35, '2022-12-29', 27.5, 10, 3),
       (122, 35, '2022-12-30', 12.5, 10, 3),
       (123, 35, '2022-12-31', 20, 10, 3),
       (124, 36, '2022-12-24', 17.5, 10, 3),
       (125, 36, '2022-12-25', 22.5, 10, 3),
       (126, 37, '2022-12-27', 45, 10, 3),
       (127, 37, '2022-12-28', 5, 10, 3),
       (128, 37, '2022-12-30', 48.25, 10, 3),
       (129, 37, '2022-12-31', 43.25, 10, 3),
       (130, 38, '2022-12-24', 57.5, 10, 3),
       (131, 38, '2022-12-25', 35, 10, 3),
       (132, 38, '2022-12-26', 27.5, 10, 3),
       (133, 39, '2022-12-26', 63.25, 10, 3),
       (134, 39, '2022-12-28', 7.5, 10, 3),
       (135, 39, '2022-12-30', 20, 10, 3),
       (136, 40, '2022-12-25', 45, 10, 3),
       (137, 40, '2022-12-29', 17.5, 10, 3),
       (138, 40, '2022-12-30', 52.5, 10, 3),
       (139, 41, '2022-12-24', 11.25, 10, 3),
       (140, 41, '2022-12-26', 43.25, 10, 3),
       (141, 42, '2022-12-27', 22.5, 10, 3),
       (142, 43, '2022-12-25', 5, 10, 3),
       (143, 43, '2022-12-26', 2.5, 10, 3),
       (144, 43, '2022-12-28', 35, 10, 3),
       (145, 43, '2022-12-29', 27.5, 10, 3),
       (146, 44, '2022-12-25', 52.5, 10, 3),
       (147, 44, '2022-12-27', 17.5, 10, 3),
       (148, 44, '2022-12-28', 20, 10, 3),
       (149, 45, '2022-12-24', 12.5, 10, 3),
       (150, 45, '2022-12-25', 43.25, 10, 3),
       (151, 45, '2022-12-29', 35, 10, 3),
       (152, 45, '2022-12-30', 7.5, 10, 3),
       (153, 46, '2022-12-26', 5, 10, 3),
       (154, 46, '2022-12-27', 52.5, 10, 3),
       (155, 46, '2022-12-28', 27.5, 10, 3),
       (156, 46, '2022-12-29', 10, 10, 3),
       (157, 47, '2022-12-24', 2.5, 10, 3),
       (158, 47, '2022-12-25', 35, 10, 3),
       (159, 48, '2022-12-26', 27.5, 10, 3),
       (160, 49, '2022-12-26', 22.5, 10, 3),
       (161, 49, '2022-12-29', 17.5, 10, 3),
       (162, 49, '2022-12-30', 20, 10, 3),
       (163, 50, '2022-12-24', 43.25, 10, 3),
       (164, 50, '2022-12-26', 45, 10, 3),
       (165, 50, '2022-12-27', 45, 10, 3),
       (166, 50, '2022-12-28', 11.25, 10, 3),
       (167, 51, '2022-12-24', 45, 10, 3),
       (168, 51, '2022-12-28', 7.5, 10, 3),
       (169, 51, '2022-12-29', 20, 10, 3),
       (170, 51, '2022-12-30', 43.25, 10, 3),
       (171, 51, '2022-12-31', 27.5, 10, 3),
       (172, 52, '2022-12-25', 22.5, 10, 3),
       (173, 52, '2022-12-27', 45, 10, 3),
       (174, 52, '2022-12-28', 5, 10, 3),
       (175, 53, '2022-12-24', 45, 10, 3),
       (176, 53, '2022-12-25', 35, 10, 3),
       (177, 53, '2022-12-26', 57.5, 10, 3),
       (178, 53, '2022-12-28', 63.25, 10, 3),
       (179, 53, '2022-12-29', 43.25, 10, 3),
       (180, 53, '2022-12-30', 52.5, 10, 3),
       (181, 53, '2022-12-31', 27.5, 10, 3),
       (182, 54, '2022-12-24', 20, 10, 3),
       (183, 54, '2022-12-25', 22.5, 10, 3),
       (184, 54, '2022-12-26', 17.5, 10, 3),
       (185, 54, '2022-12-27', 63.25, 10, 3),
       (186, 54, '2022-12-28', 12.5, 10, 3),
       (187, 55, '2022-12-24', 35, 10, 3),
       (188, 55, '2022-12-28', 45, 10, 3),
       (189, 56, '2022-12-25', 7.5, 10, 3),
       (190, 56, '2022-12-28', 45, 10, 3),
       (191, 56, '2022-12-29', 27.5, 10, 3),
       (192, 57, '2022-12-24', 11.25, 10, 3),
       (193, 57, '2022-12-29', 20, 10, 3),
       (194, 57, '2022-12-30', 43.25, 10, 3),
       (195, 58, '2022-12-25', 17.5, 10, 3),
       (196, 58, '2022-12-27', 22.5, 10, 3),
       (197, 58, '2022-12-28', 45, 10, 3),
       (198, 58, '2022-12-28', 5, 10, 3),
       (199, 59, '2022-12-26', 27.5, 10, 3),
       (200, 59, '2022-12-27', 35, 10, 3),
       (201, 59, '2022-12-28', 10, 10, 3),
       (202, 59, '2022-12-29', 2.5, 10, 3),
       (203, 60, '2022-12-24', 52.5, 10, 3),
       (204, 60, '2022-12-25', 43.25, 10, 3),
       (205, 60, '2022-12-27', 17.5, 10, 3),
       (206, 60, '2022-12-29', 35, 10, 3),
       (207, 61, '2022-12-24', 7.5, 10, 3),
       (208, 61, '2022-12-25', 1.25, 10, 3),
       (209, 61, '2022-12-26', 20, 10, 3),
       (210, 62, '2022-12-28', 22.5, 10, 3),
       (211, 62, '2022-12-30', 11.25, 10, 3),
       (212, 62, '2022-12-31', 45, 10, 3),
       (213, 63, '2022-12-25', 5, 10, 3),
       (214, 63, '2022-12-27', 35, 10, 3),
       (215, 63, '2022-12-29', 43.25, 10, 3),
       (216, 64, '2022-12-24', 27.5, 10, 3),
       (217, 64, '2022-12-25', 57.5, 10, 3),
       (218, 64, '2022-12-29', 17.5, 10, 3),
       (219, 64, '2022-12-31', 22.5, 10, 3),
       (220, 65, '2022-12-25', 20, 10, 3),
       (221, 65, '2022-12-26', 52.5, 10, 3),
       (222, 65, '2022-12-30', 35, 10, 3),
       (223, 65, '2022-12-31', 12.5, 10, 3),
       (224, 66, '2022-12-24', 7.5, 10, 3),
       (225, 66, '2022-12-25', 27.5, 10, 3),
       (226, 66, '2022-12-27', 10, 10, 3),
       (227, 66, '2022-12-28', 43.25, 10, 3),
       (228, 66, '2022-12-29', 20, 10, 3),
       (229, 66, '2022-12-31', 22.5, 10, 3),
       (230, 67, '2022-12-24', 17.5, 10, 3),
       (231, 67, '2022-12-28', 5, 10, 3),
       (232, 68, '2022-12-26', 57.5, 10, 3),
       (233, 68, '2022-12-28', 27.5, 10, 3),
       (234, 69, '2022-12-24', 35, 10, 3),
       (235, 69, '2022-12-25', 45, 10, 3),
       (236, 69, '2022-12-26', 43.25, 10, 3),
       (237, 69, '2022-12-27', 20, 10, 3),
       (238, 69, '2022-12-28', 17.5, 10, 3),
       (239, 69, '2022-12-31', 22.5, 10, 3);

insert into workout_has_exercises_jt (WORKOUT_ID, EXERCISE_ID)
VALUES (1, 1),
       (1, 2),
       (2, 3),
       (13, 3),
       (3, 4),
       (3, 5),
       (4, 6),
       (5, 7),
       (5, 8),
       (6, 9),
       (10, 9),
       (7, 10),
       (7, 11),
       (8, 12),
       (9, 13),
       (11, 14),
       (14, 14),
       (12, 15),
       (13, 16),
       (10, 17),
       (14, 17),
       (14, 18),
       (15, 19),
       (1, 20),
       (5, 20),
       (16, 20),
       (1, 21),
       (9, 21),
       (2, 22),
       (7, 22),
       (2, 23),
       (3, 24),
       (4, 25),
       (4, 26),
       (5, 27),
       (6, 28),
       (11, 28),
       (6, 29),
       (6, 30),
       (7, 31),
       (8, 32),
       (8, 33),
       (9, 34),
       (16, 34),
       (10, 35),
       (10, 36),
       (11, 36),
       (15, 36),
       (11, 37),
       (12, 38),
       (12, 39),
       (2, 40),
       (13, 40),
       (7, 40),
       (13, 41),
       (14, 42),
       (15, 42),
       (6, 43),
       (15, 43),
       (15, 44),
       (16, 45),
       (16, 46),
       (1, 47),
       (1, 48),
       (5, 48),
       (3, 50),
       (4, 51),
       (4, 52),
       (5, 53),
       (6, 54),
       (10, 54),
       (15, 54),
       (7, 55),
       (13, 55),
       (9, 56),
       (10, 57),
       (14, 57),
       (12, 58),
       (16, 59);