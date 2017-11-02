CREATE DEFINER=`root`@`localhost` PROCEDURE `UserLogin`(IN userName VARCHAR(20),IN password VARCHAR(50))
BEGIN
SELECT Id,
		UserName,
		Password,
		Name,
		CreatedBy,
		CreatedDate,
		ModifiedBy,
		ModifiedDate,
		RoleType
FROM	user
WHERE	user.UserName = userName AND user.Password = password;
END