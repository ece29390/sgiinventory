CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectWashingByName`(IN washingName varchar(25))
BEGIN

SELECT 		washing.Code
				,washing.Name				
				,CreatedDate
				,CreatedBy
				,ModifiedDate
				,ModifiedBy
	FROM		washing
	WHERE		Name = washingName;
	

END