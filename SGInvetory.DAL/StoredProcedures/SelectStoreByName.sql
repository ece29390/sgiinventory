CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectStoreByName`(IN storeName VARCHAR(100))
BEGIN

SELECT		Store.Code
			,Store.Name
			,CreatedDate
			,CreatedBy
			,ModifiedDate
			,ModifiedBy
FROM		Store
WHERE		Store.Name = storeName;

END