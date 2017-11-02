CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectWashingByCode`(IN washingCode VARCHAR(10))
BEGIN
SELECT 		washing.Code
				,washing.Name				
				,CreatedDate
				,CreatedBy
				,ModifiedDate
				,ModifiedBy
	FROM		washing
	WHERE		washing.Code = washingCode;
END