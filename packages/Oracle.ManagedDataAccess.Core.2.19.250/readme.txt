Oracle.ManagedDataAccess.Core NuGet Package 2.19.250 README
===========================================================
Release Notes: Oracle Data Provider for .NET Core

September 2024

This provider supports .NET 6.

This document provides information that supplements the Oracle Data Provider for .NET (ODP.NET) documentation.


Bug Fixes since Oracle.ManagedDataAccess.Core NuGet Package 2.19.240
====================================================================
Bug 36937681 - ORA-00917 MISSING COMMA ERROR WHEN USING Ø CHARACTER WITH CHARACTER SET ZHS16GBK 
Bug 36736236 - SETTING THE PORT WHEN USING NOTIFICATIONS CAUSES ORA-50050: THE NOTIFICATION LISTENER IS ALREADY STARTED
Bug 36656255 - STATEMENT CACHING NOT PROPERLY HANDLING UNDERLYING TABLE CHANGES


Known Issues and Limitations
============================
1) BindToDirectory throws NullReferenceException on Linux when LdapConnection AuthType is Anonymous

https://github.com/dotnet/runtime/issues/61683

This issue is observed when using System.DirectoryServices.Protocols, version 6.0.0.
To workaround the issue, use System.DirectoryServices.Protocols, version 5.0.1.

 Copyright (c) 2021, 2024, Oracle and/or its affiliates. 
