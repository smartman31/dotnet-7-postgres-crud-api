namespace WebApi.Services;

using AutoMapper;
using BCrypt.Net;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Tutorials;
using WebApi.Repositories;

public interface ITutorialService
{
    Task<IEnumerable<Tutorial>> GetAll(string? title);
    Task<Tutorial> GetById(int id);
    Task Create(CreateTutorialRequest model);
    Task Update(int id, UpdateTutorialRequest model);
    Task Delete(int id);
    Task DeleteAll();
}

public class TutorialService : ITutorialService
{
    private ITutorialRepository _tutorialRepository;
    private readonly IMapper _mapper;

    public TutorialService(
        ITutorialRepository tutorialRepository,
        IMapper mapper)
    {
        _tutorialRepository = tutorialRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Tutorial>> GetAll(string? title)
    {
        return await _tutorialRepository.GetAll(title);
    }

    public async Task<Tutorial> GetById(int id)
    {
        var tutorial = await _tutorialRepository.GetById(id);

        if (tutorial == null)
            throw new KeyNotFoundException("Tutorial not found");

        return tutorial;
    }

    public async Task Create(CreateTutorialRequest model)
    {
        // map model to new tutorial object
        var tutorial = _mapper.Map<Tutorial>(model);

        if (tutorial == null)
            throw new KeyNotFoundException("Tutorial didn't create");

        // save tutorial
        await _tutorialRepository.Create(tutorial);
    }

    public async Task Update(int id, UpdateTutorialRequest model)
    {
        var tutorial = await _tutorialRepository.GetById(id);

        if (tutorial == null)
            throw new KeyNotFoundException("Tutorial not found");

        // copy model props to tutorial
        _mapper.Map(model, tutorial);

        // save tutorial
        await _tutorialRepository.Update(tutorial);
    }

    public async Task Delete(int id)
    {
        await _tutorialRepository.Delete(id);
    }

    public async Task DeleteAll()
    {
        await _tutorialRepository.DeleteAll();
    }
}