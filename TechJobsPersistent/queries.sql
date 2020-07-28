--Part 1
select * from jobs

--Part 2

select * from employers
where Location="st louis";

--Part 3
select skills.Id, skills.Name, skills.Description
from skills
inner join jobskills on skills.Id=jobskills.SkillId
order by skills.Name;
