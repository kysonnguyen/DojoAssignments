SELECT countries.name, cities.name, cities.population from countries
join cities on countries.id = cities.country_id
where countries.name = 'Mexico' and cities.population > 500000
order by population desc;