use TimeManager
go

INSERT INTO Category ( [Name] ) values 
('Learning'),
('Workout'),
('Rest'),
('Work'),
('Other'),

INSERT INTO Activity ( [Name], [Description], CategoryId ) values
('Math','learn algebra 1-10', 1),
('Math','learn algebra 10-20', 1),
('Math','learn algebra 20-30', 1),
('Math','learn algebra 30-40', 1),
('Math','learn algebra 40-50', 1),
('Math','learn algebra 50-60', 1),
('Math','learn algebra 60-70', 1),
('OOP','read about object oriented programming', 1),
('OOP','read about encapsulation', 1),
('Algorithms','read about quicksort', 1),
('Algorithms','write quicksort implementation', 1),
('Training','Make chest training', 2),
('Running','Run 5km', 2),
('Chill','Take a 30min break', 3),
('Method','Complete 12c task with method implementation', 4),
('Walk', 'Take your dog for a walk', 5)

