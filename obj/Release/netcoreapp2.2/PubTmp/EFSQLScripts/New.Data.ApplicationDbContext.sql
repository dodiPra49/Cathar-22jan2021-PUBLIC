IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(128) NOT NULL,
        [ProviderKey] nvarchar(128) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(128) NOT NULL,
        [Name] nvarchar(128) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'00000000000000_CreateIdentitySchema', N'2.2.0-rtm-35687');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Discriminator] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Alamat] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [KabKota] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Name] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Provinsi] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Telpon] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE TABLE [HariKerja] (
        [Tanggal] date NOT NULL,
        [IdLibur] int NOT NULL,
        CONSTRAINT [PK_HariKerja] PRIMARY KEY ([Tanggal])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE TABLE [HariKerjaStatus] (
        [Id] int NOT NULL,
        [Uraian] varchar(254) NOT NULL,
        [Libur] bit NOT NULL,
        CONSTRAINT [PK_HariKerjaStatus] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE TABLE [JamKerjaPola] (
        [Id] int NOT NULL,
        [Uraian] varchar(254) NOT NULL,
        [MasukA] time NULL,
        [KeluarA] time NOT NULL,
        [MasukB] time NOT NULL,
        [KeluarB] time NOT NULL,
        [Jumlah] int NULL,
        CONSTRAINT [PK_JamKerjaPola] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE TABLE [Pegawai] (
        [NIP] varchar(18) NOT NULL,
        [Nama] varchar(50) NOT NULL,
        [GelarDepan] varchar(8) NULL,
        [GelarBelakang] varchar(25) NULL,
        [TempatLahir] varchar(30) NOT NULL,
        [TgLLahir] date NULL,
        CONSTRAINT [PK_Pegawai] PRIMARY KEY ([NIP])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE TABLE [Periode] (
        [Id] varchar(7) NOT NULL,
        [Tahun] int NULL,
        [Bulan] int NULL,
        CONSTRAINT [PK_Periode] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE TABLE [UnitKerja] (
        [Id] int NOT NULL,
        [UnitKerja] varchar(200) NOT NULL,
        [IdLevel] int NOT NULL,
        CONSTRAINT [PK_UnitKerja] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE TABLE [Jabatan] (
        [Id] int NOT NULL,
        [IdUnitKerja] int NOT NULL,
        [Uraian] varchar(150) NOT NULL,
        [IdEselon] int NOT NULL,
        [Urut] int NOT NULL,
        [IdJabatan] int NOT NULL,
        [IdAtas] int NOT NULL,
        CONSTRAINT [PK_Jabatan] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Jabatan_UnitKerja] FOREIGN KEY ([IdUnitKerja]) REFERENCES [UnitKerja] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE TABLE [PeriodeKaSKPD] (
        [IdPeriode] varchar(7) NOT NULL,
        [IdUnitKerja] int NOT NULL,
        [IdJabatan] int NOT NULL,
        [IdKaSKPD] varchar(18) NOT NULL,
        CONSTRAINT [PK_PeriodeKaSKPD] PRIMARY KEY ([IdPeriode], [IdUnitKerja]),
        CONSTRAINT [FK_PeriodeKaSKPD_Jabatan] FOREIGN KEY ([IdJabatan]) REFERENCES [Jabatan] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_PeriodeKaSKPD_Pegawai] FOREIGN KEY ([IdKaSKPD]) REFERENCES [Pegawai] ([NIP]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE TABLE [PeriodeNIP] (
        [IdPeriode] varchar(7) NOT NULL,
        [Nip] varchar(18) NOT NULL,
        [IdUnitKerja] int NOT NULL,
        [IdJabatan] int NOT NULL,
        [NipAtas1] varchar(18) NOT NULL,
        [NipAtas2] varchar(18) NOT NULL,
        [IdJabatanAtas1] int NOT NULL,
        [IdJabatanAtas2] int NOT NULL,
        CONSTRAINT [PK_PeriodeNIP] PRIMARY KEY ([IdPeriode], [Nip]),
        CONSTRAINT [FK_PeriodeNIP_Jabatan] FOREIGN KEY ([IdJabatan]) REFERENCES [Jabatan] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_PeriodeNIP_Jabatan1] FOREIGN KEY ([IdJabatanAtas1]) REFERENCES [Jabatan] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_PeriodeNIP_Jabatan2] FOREIGN KEY ([IdJabatanAtas2]) REFERENCES [Jabatan] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_PeriodeNIP_Periode] FOREIGN KEY ([IdPeriode]) REFERENCES [Periode] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_PeriodeNIP_UnitKerja] FOREIGN KEY ([IdUnitKerja]) REFERENCES [UnitKerja] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_PeriodeNIP_Pegawai] FOREIGN KEY ([Nip]) REFERENCES [Pegawai] ([NIP]) ON DELETE NO ACTION,
        CONSTRAINT [FK_PeriodeNIP_Pegawai1] FOREIGN KEY ([NipAtas1]) REFERENCES [Pegawai] ([NIP]) ON DELETE NO ACTION,
        CONSTRAINT [FK_PeriodeNIP_Pegawai2] FOREIGN KEY ([NipAtas2]) REFERENCES [Pegawai] ([NIP]) ON DELETE NO ACTION,
        CONSTRAINT [FK_PeriodeNIP_PeriodeKaSKPD] FOREIGN KEY ([IdPeriode], [IdUnitKerja]) REFERENCES [PeriodeKaSKPD] ([IdPeriode], [IdUnitKerja]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE TABLE [Diary] (
        [Id] int NOT NULL,
        [IdPeriode] varchar(7) NOT NULL,
        [Nip] varchar(18) NOT NULL,
        [Tanggal] date NOT NULL,
        [WaktuMulai] time NOT NULL,
        [WaktuHingga] time NOT NULL,
        [Aktifitas] varchar(254) NOT NULL,
        [Tempat] varchar(254) NOT NULL,
        [Hasil] varchar(254) NOT NULL,
        [WaktuSetuju1] int NOT NULL,
        [WaktuSetuju2] int NOT NULL,
        CONSTRAINT [PK_Diary] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Diary_PeriodeNIP] FOREIGN KEY ([IdPeriode], [Nip]) REFERENCES [PeriodeNIP] ([IdPeriode], [Nip]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE TABLE [HariKerjaNip] (
        [IdPeriode] varchar(7) NOT NULL,
        [NIP] varchar(18) NOT NULL,
        [Tanggal] date NOT NULL,
        [IdHariKerjaStatus] int NOT NULL,
        CONSTRAINT [PK_HariKerjaNip] PRIMARY KEY ([IdPeriode], [NIP], [Tanggal]),
        CONSTRAINT [FK_HariKerjaNip_HariKerjaStatus] FOREIGN KEY ([IdHariKerjaStatus]) REFERENCES [HariKerjaStatus] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_HariKerjaNip_PeriodeNIP] FOREIGN KEY ([IdPeriode], [NIP]) REFERENCES [PeriodeNIP] ([IdPeriode], [Nip]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE INDEX [IX_Diary_IdPeriode_Nip] ON [Diary] ([IdPeriode], [Nip]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE INDEX [IX_HariKerjaNip_IdHariKerjaStatus] ON [HariKerjaNip] ([IdHariKerjaStatus]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE INDEX [IX_Jabatan_IdUnitKerja] ON [Jabatan] ([IdUnitKerja]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE INDEX [IX_PeriodeKaSKPD_IdJabatan] ON [PeriodeKaSKPD] ([IdJabatan]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE INDEX [IX_PeriodeKaSKPD_IdKaSKPD] ON [PeriodeKaSKPD] ([IdKaSKPD]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE INDEX [IX_PeriodeNIP_IdJabatan] ON [PeriodeNIP] ([IdJabatan]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE INDEX [IX_PeriodeNIP_IdJabatanAtas1] ON [PeriodeNIP] ([IdJabatanAtas1]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE INDEX [IX_PeriodeNIP_IdJabatanAtas2] ON [PeriodeNIP] ([IdJabatanAtas2]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE INDEX [IX_PeriodeNIP_IdUnitKerja] ON [PeriodeNIP] ([IdUnitKerja]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE INDEX [IX_PeriodeNIP_Nip] ON [PeriodeNIP] ([Nip]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE INDEX [IX_PeriodeNIP_NipAtas1] ON [PeriodeNIP] ([NipAtas1]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE INDEX [IX_PeriodeNIP_NipAtas2] ON [PeriodeNIP] ([NipAtas2]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    CREATE INDEX [IX_PeriodeNIP_IdPeriode_IdUnitKerja] ON [PeriodeNIP] ([IdPeriode], [IdUnitKerja]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627115213_AddMoreFieldsToIdentityUs')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190627115213_AddMoreFieldsToIdentityUs', N'2.2.0-rtm-35687');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190703060040_RemoveNipUnitkerja')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Alamat');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [AspNetUsers] DROP COLUMN [Alamat];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190703060040_RemoveNipUnitkerja')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'KabKota');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [AspNetUsers] DROP COLUMN [KabKota];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190703060040_RemoveNipUnitkerja')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Name');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [AspNetUsers] DROP COLUMN [Name];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190703060040_RemoveNipUnitkerja')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Provinsi');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [AspNetUsers] DROP COLUMN [Provinsi];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190703060040_RemoveNipUnitkerja')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Telpon');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [AspNetUsers] DROP COLUMN [Telpon];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190703060040_RemoveNipUnitkerja')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190703060040_RemoveNipUnitkerja', N'2.2.0-rtm-35687');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190703060249_AddNipUnitKerja')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [NIP] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190703060249_AddNipUnitKerja')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [UnitKerja] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190703060249_AddNipUnitKerja')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190703060249_AddNipUnitKerja', N'2.2.0-rtm-35687');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190708071120_addFieldNamaToAspUser')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserTokens]') AND [c].[name] = N'Name');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserTokens] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [AspNetUserTokens] ALTER COLUMN [Name] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190708071120_addFieldNamaToAspUser')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserTokens]') AND [c].[name] = N'LoginProvider');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserTokens] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [AspNetUserTokens] ALTER COLUMN [LoginProvider] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190708071120_addFieldNamaToAspUser')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Nama] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190708071120_addFieldNamaToAspUser')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserLogins]') AND [c].[name] = N'ProviderKey');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserLogins] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [AspNetUserLogins] ALTER COLUMN [ProviderKey] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190708071120_addFieldNamaToAspUser')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserLogins]') AND [c].[name] = N'LoginProvider');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserLogins] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [AspNetUserLogins] ALTER COLUMN [LoginProvider] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190708071120_addFieldNamaToAspUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190708071120_addFieldNamaToAspUser', N'2.2.0-rtm-35687');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190715070103_PegTglPensiun')
BEGIN
    ALTER TABLE [Pegawai] ADD [TglPensiun] date NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190715070103_PegTglPensiun')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190715070103_PegTglPensiun', N'2.2.0-rtm-35687');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190715074613_addIdJamkerjaPolaAtPeriodeNip')
BEGIN
    ALTER TABLE [PeriodeNIP] ADD [IdJamKerjaPola] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190715074613_addIdJamkerjaPolaAtPeriodeNip')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190715074613_addIdJamkerjaPolaAtPeriodeNip', N'2.2.0-rtm-35687');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190715080046_AddJoinPeriodeNipToJamKerjaPola')
BEGIN
    CREATE INDEX [IX_PeriodeNIP_IdJamKerjaPola] ON [PeriodeNIP] ([IdJamKerjaPola]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190715080046_AddJoinPeriodeNipToJamKerjaPola')
BEGIN
    ALTER TABLE [PeriodeNIP] ADD CONSTRAINT [FK_PeriodeNIP_JamKerjaPola_IdJamKerjaPola] FOREIGN KEY ([IdJamKerjaPola]) REFERENCES [JamKerjaPola] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190715080046_AddJoinPeriodeNipToJamKerjaPola')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190715080046_AddJoinPeriodeNipToJamKerjaPola', N'2.2.0-rtm-35687');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190715080348_JamKerjaPolaAddSeninSDMinggu')
BEGIN
    ALTER TABLE [JamKerjaPola] ADD [Jum] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190715080348_JamKerjaPolaAddSeninSDMinggu')
BEGIN
    ALTER TABLE [JamKerjaPola] ADD [Kam] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190715080348_JamKerjaPolaAddSeninSDMinggu')
BEGIN
    ALTER TABLE [JamKerjaPola] ADD [Mgg] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190715080348_JamKerjaPolaAddSeninSDMinggu')
BEGIN
    ALTER TABLE [JamKerjaPola] ADD [Rab] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190715080348_JamKerjaPolaAddSeninSDMinggu')
BEGIN
    ALTER TABLE [JamKerjaPola] ADD [Sab] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190715080348_JamKerjaPolaAddSeninSDMinggu')
BEGIN
    ALTER TABLE [JamKerjaPola] ADD [Sel] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190715080348_JamKerjaPolaAddSeninSDMinggu')
BEGIN
    ALTER TABLE [JamKerjaPola] ADD [Sen] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190715080348_JamKerjaPolaAddSeninSDMinggu')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190715080348_JamKerjaPolaAddSeninSDMinggu', N'2.2.0-rtm-35687');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190715084513_AddHariKerja')
BEGIN
    CREATE INDEX [IX_HariKerja_IdLibur] ON [HariKerja] ([IdLibur]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190715084513_AddHariKerja')
BEGIN
    ALTER TABLE [HariKerja] ADD CONSTRAINT [FK_HariKerja_HariKerjaStatus_IdLibur] FOREIGN KEY ([IdLibur]) REFERENCES [HariKerjaStatus] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190715084513_AddHariKerja')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190715084513_AddHariKerja', N'2.2.0-rtm-35687');
END;

GO

