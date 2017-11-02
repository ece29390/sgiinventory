CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectSizeByName`(IN sizeName VARCHAR(20))
BEGIN

SELECT 		    size.Code
				,size.Name				
				,CreatedDate
				,CreatedBy
				,ModifiedDate
				,ModifiedBy
	FROM		size
	WHERE		size.Name = sizeName;

END