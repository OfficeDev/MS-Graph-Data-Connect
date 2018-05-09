This sample demonstrates how to use a user list instead of entire tenant for o365 data extraction
>**NOTE:** The userlist file can have at most 10 users. For format refer `userlist.txt` file.

1. `UserListLinkedService ` corresponds to the store that has the userlist.
2. `UserListDataSet ` corresponds to the file in the store represented by `UserListLinkedService `.
3. `CopyMessageFromO365ToAzureDLS ` copy activity uses the `UserListDataSet `.

   ```shell
   "userList": {
     "type": "DatasetReference",
     "referenceName": "[variables('userListDatasetName')]"
   }
   ```