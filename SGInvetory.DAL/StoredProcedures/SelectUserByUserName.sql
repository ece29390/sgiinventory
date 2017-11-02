CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectUserByUserName`(IN userName varchar(20))
BEGIN

select Id,
	   UserName,
		Password,
		Name,
		CreatedBy,
		CreatedDate,
		ModifiedBy,
		ModifiedDate,
		RoleType
FROm  user
WHERE  user.UserName = userName;

END