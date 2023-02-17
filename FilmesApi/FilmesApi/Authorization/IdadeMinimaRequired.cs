using Microsoft.AspNetCore.Authorization;

namespace FilmesApi.Authorization;

public class IdadeMinimaRequired : IAuthorizationRequirement
{
    public int IdadeMinima { get; set; }

	public IdadeMinimaRequired(int idadeMinima)
	{
		IdadeMinima = idadeMinima;
	}
}
