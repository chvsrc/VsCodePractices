DROP TABLE IF EXISTS [DBO].[AppLanguageResources];
CREATE TABLE [DBO].[AppLanguageResources] (
	[Id] [nvarchar](128) NOT NULL DEFAULT NEWID(),
	--
	[ApplicationID] [int] NOT NULL,
	[LanguageCode] [nvarchar](20) NOT NULL,
	[ResourceID] [nvarchar](200) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[TranslatedString] [nvarchar](4000),
	--
	[Version] rowversion NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL DEFAULT SYSUTCDATETIME(),
	[UpdatedAt] [datetimeoffset](7) DEFAULT SYSUTCDATETIME(),
	[Deleted] [bit] NOT NULL,
	CONSTRAINT [PK_DBO.AppLanguageResources] PRIMARY KEY NONCLUSTERED ([Id])
);
-------------------------
-- TRIGGER for UpdatedAt 
-- Note:: some times MUST use Exec(N' --- ');
-------------------------
Exec(N'
	CREATE TRIGGER [TR_DBO_AppLanguageResources_InsertUpdateDelete] ON [DBO].[AppLanguageResources] 
		AFTER INSERT, UPDATE, DELETE 
		AS BEGIN 
		    UPDATE [DBO].[AppLanguageResources] 
		    SET [DBO].[AppLanguageResources].[UpdatedAt] = CONVERT(DATETIMEOFFSET, SYSUTCDATETIME()) 
		    FROM INSERTED 
		    WHERE inserted.[Id] = [DBO].[AppLanguageResources].[Id] 
		END
');
-------------------------
-- CLUSTERED INDEX for speed up searches/queries base on CreatedAt 
-------------------------
CREATE CLUSTERED INDEX [IX_CreatedAt] ON [DBO].[AppLanguageResources]([CreatedAt]);
-------------------------
-- OPTIONAL 
-------------------------
CREATE UNIQUE INDEX [IX_AppLanguageResources] ON [DBO].[AppLanguageResources]([ApplicationID]);
