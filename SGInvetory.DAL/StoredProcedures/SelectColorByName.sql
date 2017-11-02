CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectColorByName`(IN colorName VARCHAR(100))
BEGIN

SELECT		color.Code
			,color.Name
			,CreatedDate
			,CreatedBy
			,ModifiedDate
			,ModifiedBy
FROM		color
WHERE		color.Name = colorName;

END