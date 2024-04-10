using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OOmiNet.Models;

namespace OOmiNet.Tests.Models;
public class TestOomiRecord : OomiRecord
{
	[OomiProperty]
	public string? DirectoryContactName { get; set; }
}

public class TestInsertRecord : OomiInsertRecord
{
	public override string EntityName => "CONTACT";

	[OomiProperty]
	public string? LoginUserName { get; set; }
}
