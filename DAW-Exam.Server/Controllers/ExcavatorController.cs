using System;
using System.Collections.Generic;
using DAW_Exam.Server.Entities;
using DAW_Exam.Server.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAW_Exam.Server.Contexts;


[ApiController]

[Route("api/[controller]")]

public class ExcavatorController : ControllerBase

{

    private readonly DawContext _context;

    public ExcavatorController(DawContext context)
    {

        _context = context;

    }

    [HttpGet]

    public IEnumerable<ExcavatorDTO> Get()

    {

        var excavators = _context.Excavators.Include(e => e.ExcavatorType);

        var excavatorsDTO = new List<ExcavatorDTO>();

        foreach (var excavator in excavators)

        {

            var excavatorDTO = new ExcavatorDTO

            {

                Id = excavator.Id,

                Model = excavator.Model,

                Manufacturer = excavator.Manufacturer,

                YearOfFabrication = excavator.YearOfFabrication,

                Weight = excavator.Weight,

            };

            excavatorsDTO.Add(excavatorDTO);

        }

        return excavatorsDTO;

    }

    [HttpGet("{id}")]

    public ExcavatorDTO Get(int id)

    {

        var excavator = _context.Excavators.Include(e => e.ExcavatorType).FirstOrDefault(e => e.Id == id);

        var excavatorDTO = new ExcavatorDTO

        {

            Id = excavator.Id,

            Model = excavator.Model,

            Manufacturer = excavator.Manufacturer,

            YearOfFabrication = excavator.YearOfFabrication,

            Weight = excavator.Weight,

        };

        return excavatorDTO;

    }

    [HttpPost]

    public Excavator Post([FromBody]ExcavatorDTO excavatorDTO)

    {

        var excavator = new Excavator

        {

            Model = excavatorDTO.Model,

            Manufacturer = excavatorDTO.Manufacturer,

            YearOfFabrication = excavatorDTO.YearOfFabrication,

            Weight = excavatorDTO.Weight,

        };

        _context.Excavators.Add(excavator);

        _context.SaveChanges();

        return excavator;

    }

    [HttpPut]

    public Excavator Put([FromBody]ExcavatorDTO excavatorDTO)

    {

        var excavator = _context.Excavators.Find(excavatorDTO.Id);

        if (excavator != null)

        {

            excavator.Model = excavatorDTO.Model;

            excavator.Manufacturer = excavatorDTO.Manufacturer;

            excavator.YearOfFabrication = excavatorDTO.YearOfFabrication;

            excavator.Weight = excavatorDTO.Weight;

            _context.SaveChanges();

        }

        return excavator;

    }

}

