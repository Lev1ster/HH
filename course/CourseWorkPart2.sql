use CourseWork
INSERT INTO Race
VALUES ('Elf', '�������������� ����������� ����, ������������ ����������� ����� � 
������� ���������, ���� �� ���, ����������� � ������� �������. 
�����-�� ��� ����� ���� ������ ������� ������, Aen Undod[1], ��������������� ������� �� 
���������� ����. ����� ����������� ����������, ������������ �� ������ ���,
Aen Undod �������� ������� ����� �����. �� ������� ����������� �� ��� ������ ������ � 
Aen Elle (����� ����), ���������� ���� �� ����� � �������� ���, 
� Aen Seidhe (����� ���), ���������� �� ����� ����� �������� �� ��������� ����� ��� ���� ����� 
���������� ����, �� ��������� ��� �� ����� � �� ����������� ����� ������ � �����������. 
������ � ������� ��������� �� ��������� Aen Seidhe ���������� ������ ����� ����� ���.'),

('Human', 'C���� ������� � �������� �������������� ���� �� ����������, 
������������ ������� ����� ��������� �������� ���������� � �������������� �������.
����� �������� �� ��������� ���� ������ ����������� ���������, ���������� ���������� 
�������� ������ �����. � ���������� ��� ����� ������������ �����, ����� ��� �����, ���������� � ������
����� ���������� ��������.'),

('Bobolak', ' ����������� ����, ������������ �������� �������� ������� � ����� ������ ������. 
��� �������� ������� �� �������� �����, ������ � ������� ���� � ������ ���������� �����������, 
���������� ��� ������ ����. ������ � ����� � ������� �� ���� ���������� ������� �������� ����������,
�������� ���� ����� ��������� ���������� ������, ��������� �������� �������� ���������� � ����� � 
������. � ����������, � 1250-�� ����� �������� ������� ������ � �������� � ��������������� ����� � 
�������')

INSERT INTO Class
VALUES ('Papidin', '������� � ����������� ����� ��������� �� ������� Arthas`a. ��� ���� ���������
������, ��� �� �������� ���� ������ ��������� ����� ������.', 1),

('Dungeon Master', '��� ����������� Finger ������� ����� � ������ ����� ����������. ����������� ������
� ���, ��� �� �������� ���� � 300 ��������', 2),

('EvilArthas', '���� ����������� �������, ����� ����� ���� � ����� � ���� ���, �� EvilArthas ������
���� ��� ����������� ����. ��� ������� ����������� "��� ������" ��������� �������� ����� �������� ����
��� ���������� ����� ����������', 1),

('SlavnyPivovar', '������ ��� �� ������� "������� �����" �������� ���������� ����� ����� ���� 
����������� ����� "Beer". ��� ����� ��� �� �� ������ � ������ ������ � ���������� �� �������.', 2),

('Enko', '������� �� ������������� SAPR. �������� ����� ���� �� ���������� 10��. ������� ���� � 
������� �������� ��������� ����������� �����, ��� �� �� �� ���������', 1),

('����', '�������� ������, ����������� � ����� �����, ������ ���������� ��� ����� �� �����. �� � ����
�� ������? ������� �� � ������� �����. ������� ����� MatLab, ��� ��������� �������� � ������ ����.
�� ������ �������� ��� ���������, � �� ��� ����� ������������� ����� ����, ��� ����� � ��������', 3)

INSERT INTO Talants
VALUES ('���', '������� ���� �������� �������� ����������', 1),
('�_��������', '���� ������� ����� ����������', 1),
('��������', '�������� ����� � ������', 1),

('FingerAttack', '��������� ������� �� ���� ����� ����, �� �������� ���� � ����������', 2),
('Slaves', '��������� ����� ��� ��������', 2),
('300gold', '��������� �����������, ������� ���� ���������� 300 �������', 2),

('��������� ����������', '��������� �����������. �������� ����� ����� ��������', 3),
('���_��_�����', '����������� ����, ������� �������� ����. ���� � �������� �����', 3),
('������!', '���� ���������� ����� ����������', 3),

('BeerBall', '������ ���', 4),
('BeerStorm', '������ �����', 4),
('BeerImmunity', '��������� �����������. �� ������� �� ����������', 4),

('������� �������', '���������� ������� � ����', 5),
('�� ������� �������', '������� � ������ � ���������', 5),
('��������� �����', '������� �������� �� ���������� ��������� ����������� ����', 5),

('�����������������', '������������ ���������� �����, ����� ���� ��� �������.', 6),
('��_����_��_������', '�������� ����������, ����� ������� �� ������������ �����������', 6),
('Overflow', '���������� �� ���������� MatLab � ��������. ���� ��������� � ���������� ��������� �� ��
�����', 6)

EXEC Registration 'EMVEVM', 'Loveyou', 'Xo4u$datI', 'EvilArthas', 0
EXEC Registration 'SAPRVS', 'SAPRVS', 'ADMINBD', '����', 1

INSERT INTO Achivments
VALUES ('��� ������', '������� ��� ������ ������'),
('�����������', '�������� ������������ �������'),
('������', '��������� ������� ������'),
('����', '�������� ������ �������'),
('���', '�������� ������� �������'),
('�����������������', '�������� �������� �������')

INSERT INTO Items
VALUES ('Excalibur', '����������� ��� ������ ����������, ��� ���� ����', 'sword', '999999999999'),
('BowCommon','������� ���','bow','000900000004'),
('BowRare', '������ ���', 'bow', '001200000009'),
('BowSkull','���� �� �����??', 'bow', '052000060912'),
('TheKillerShot', '����????', 'bow', '103000101215'),
('TheElderSword', '������� ���', 'sword', '100500000004'),
('SwordOfStorms', '��� ���� ������ ����', 'sword', '170700000310')

INSERT INTO Monsters
VALUES ('����������', '������� ������ ������� � �����', 28, 300, 5000, 80, 1),
('BonesOfDragon', '������� ������ ������� ������� � ������', 18, 120, 1000, 25, 0),
('LEGENDARY', '����������� ����', 10, 100, 500, 10, 1)

INSERT INTO LootMonster
VALUES (1, 1, 99),
(2,3, 20),
(2,4,5),
(3,6,40),
(3,7,3)
