USE [ZebraRFID_DockDoor]
GO
SET IDENTITY_INSERT[dbo].[StorageUnits] ON
GO
INSERT[dbo].[StorageUnits]([Id], [Name], [Description], [Direction]) VALUES(1, N'DOCKDOOR_OUT_WH1', N'DockDoor OUT Warehouse 1', 2)
GO
INSERT[dbo].[StorageUnits] ([Id], [Name], [Description], [Direction]) VALUES(2, N'DOCKDOOR_IN_WH2', N'DockDoor IN Warehouse 2', 1)
GO
INSERT[dbo].[StorageUnits] ([Id], [Name], [Description], [Direction]) VALUES(3, N'TRUCK', N'TRUCK', 0)
GO
SET IDENTITY_INSERT[dbo].[StorageUnits] OFF
GO
SET IDENTITY_INSERT[dbo].[Equipments] ON
GO
INSERT[dbo].[Equipments]([Id], [Name], [Description], [ReferenceStorageUnitId]) VALUES(1, N'myfxOUT', N'Fixed Reader in Warehouse 1 (add yours or change name)', 1)
GO
INSERT[dbo].[Equipments] ([Id], [Name], [Description], [ReferenceStorageUnitId]) VALUES(2, N'myfxIN', N'Fixed Reader in Warehouse 2 (add yours or change name)', 2)
GO
SET IDENTITY_INSERT[dbo].[Equipments] OFF
GO
SET IDENTITY_INSERT[dbo].[Sublots] ON
GO
SET IDENTITY_INSERT[dbo].[Sublots] OFF
