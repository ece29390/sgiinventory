CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectStoreByCode`(IN storeCode VARCHAR(10))
BEGIN

SELECT      store.Code
			,store.Name
			,CreatedDate
			,CreatedBy
			,ModifiedDate
			,ModifiedBy
FROM		store
WHERE		store.Code = storeCode;


END