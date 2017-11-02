CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectSizeByCode`(IN sizeCode varchar(10))
BEGIN

SELECT 		    size.Code
				,size.Name				
				,CreatedDate
				,CreatedBy
				,ModifiedDate
				,ModifiedBy
	FROM		size
	WHERE		size.Code = sizeCode;

END