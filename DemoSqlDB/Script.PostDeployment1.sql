/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


set identity_insert [dbo].[Country] on
go

insert into [dbo].[Country] ([Id], [Name]) values ('Italy');
insert into [dbo].[Country] ([Id], [Name]) values ('France');
insert into [dbo].[Country] ([Id], [Name]) values ('Germany');
go

set identity_insert [dbo].[Country] off
go