CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectColorByCode`(IN colorCode VARCHAR(10))
BEGIN

SELECT      color.Code
			,color.Name
			,CreatedDate
			,CreatedBy
			,ModifiedDate
			,ModifiedBy
FROM		color
WHERE		color.Code = colorCode;

END