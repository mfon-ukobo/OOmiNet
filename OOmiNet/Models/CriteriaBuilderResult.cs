using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOmiNet.Models;
public class CriteriaBuilderResult
{
	public required List<OomiRequestCriteria> Criterias;
	public required string Logic { get; set; }
}
