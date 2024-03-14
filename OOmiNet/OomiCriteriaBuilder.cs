using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OOmiNet.Models;

namespace OOmiNet;
public class OomiCriteriaBuilder
{
	public OomiCriteriaBuilder(OomiRequestCriteria startCriteria)
	{
		startCriteria.SetRank(1);
		Criterias = new()
		{
			startCriteria
		};
		Logic = $"{startCriteria.Rank}";
	}

	protected string Logic { get; private set; }
	public List<OomiRequestCriteria> Criterias { get; set; }

	public OomiCriteriaBuilder And(OomiRequestCriteria criteria)
	{
		criteria.SetRank(Criterias.Count + 1);
		Criterias.Add(criteria);
		Logic += $" AND {criteria.Rank}";
		return this;
	}

	public OomiCriteriaBuilder Or(OomiRequestCriteria criteria)
	{
		criteria.SetRank(Criterias.Count + 1);
		Criterias.Add(criteria);
		Logic += $" OR {criteria.Rank}";
		return this;
	}

	public CriteriaBuilderResult Build()
	{
		return new CriteriaBuilderResult { Criterias = Criterias, Logic = Logic };
	}
}
