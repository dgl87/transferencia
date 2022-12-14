# VSCode - Copyright © Rubens Mussi Cury 2020 All Rights Reserved

/*
---------------------------------------------------------------
CÓDIGO NÃO OTIMIZADO
---------------------------------------------------------------
*/
# Utilizando UNION ALL e data desagrupada.
SELECT
    max, ROUND((max-32)*5/9,1) celsius, mo, da, year
FROM
   (SELECT * FROM `bigquery-public-data.noaa_gsod.gsod1930` UNION ALL
    SELECT * FROM `bigquery-public-data.noaa_gsod.gsod1931` UNION ALL
    SELECT * FROM `bigquery-public-data.noaa_gsod.gsod1932` UNION ALL
    SELECT * FROM `bigquery-public-data.noaa_gsod.gsod1933` UNION ALL
    SELECT * FROM `bigquery-public-data.noaa_gsod.gsod1934` UNION ALL
    SELECT * FROM `bigquery-public-data.noaa_gsod.gsod1935` UNION ALL
    SELECT * FROM `bigquery-public-data.noaa_gsod.gsod1936` UNION ALL
    SELECT * FROM `bigquery-public-data.noaa_gsod.gsod1937` UNION ALL
    SELECT * FROM `bigquery-public-data.noaa_gsod.gsod1938` UNION ALL
    SELECT * FROM `bigquery-public-data.noaa_gsod.gsod1939` UNION ALL
    SELECT * FROM `bigquery-public-data.noaa_gsod.gsod1940`)
WHERE
    da = "18" AND
    mo = "11" AND
    year = "1940" AND
    max <> 9999.9
ORDER BY
    max DESC


/*
Duração	
1,9 s
Bytes processados	
9,22 MB
Bytes faturados	
110 MB
Custo estimado
0.00005
*/

/*
---------------------------------------------------------------
CÓDIGO OTIMIZADO
---------------------------------------------------------------
*/
# Utilizando procedimento de UNION através 
# da técnica WILDCARD e PARTITIONED.
SELECT
    max, ROUND((max-32)*5/9,1) celsius, mo, da, year
FROM
    `bigquery-public-data.noaa_gsod.gsod19*`
WHERE
    # Ao invés de 3 colunas de dia, mês e ano, 
    # criar uma de data e particionar a tabela.
    COLUNA_DATA_PARTICIONADA = "1940-11-18" AND
    # Note que o _TABLE_SUFFIX 
    # entrega valores em STRING 
    _TABLE_SUFFIX BETWEEN "30" AND "40" AND
    max <> 9999.9
ORDER BY
    max DESC

/*
Duração	
0.6 sec (68% mais rápida)
Bytes processados		
12.57 MB
Custo estimado
13 MB (88% mais barato)
*/