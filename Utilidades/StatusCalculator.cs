using IntegramsaUltimate.Controllers;
using IntegramsaUltimate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Utilidades
{
    public static class StatusCalculator
    {
        static readonly IntegramsaUltimateEntities db;
        static StatusCalculator()
        {
            db = new IntegramsaUltimateEntities();
        }

        public static int? CalculateStatus(StatusInput input)
        {

            

            bool semanaAnterior = db.inventarios.Any(
                                                     d => d.idProducto == input.idProducto
                                                     && d.idTienda == input.idTienda
                                                     && d.numSemana == input.numSemana - 1
                                                    );
            if (semanaAnterior)
            {
                int? statusPrevio = db.inventarios.First(
                                                       d => d.idProducto == input.idProducto
                                                       && d.idTienda == input.idTienda
                                                       && d.numSemana == input.numSemana - 1)
                                                       .idEstatusInv;
                if (input.idInventarioActual == 7  || statusPrevio == 7 )
                {
                    return 8;
                }                
                else
                {
                    var condicionInventarioActual = input.idInventarioActual == 8;
                    var condicionStatusPrevio = statusPrevio == 8;
                    input.idInventarioActual = condicionInventarioActual ? 5 : input.idInventarioActual;
                    statusPrevio = condicionStatusPrevio ? 5 : statusPrevio;
                    int? idCriterio = db.inventarioCriteriosRes.First(d => d.idCriterioSemAnt == statusPrevio && d.idCriterioSemVig == input.idInventarioActual).idCriterioResultante;
                    return idCriterio;
                }           

            }
            else
            {
                return 8;
            }
        }

        public static Tuple<int?, decimal?> CalculateActualStatus(int idSemana, int? idProducto, int? idTienda, decimal ventaActual, int idCliente, decimal inventario)
        {
            Tuple<int?, decimal?> result;

            var criterios = db.estatusPorCliente.Where(d => d.idCliente == idCliente).ToList();
            var toxico = criterios.Where(d => d.idEstatus == 5).First();
            var agotado = criterios.Where(d => d.idEstatus == 6).First();
            var ventaCero = criterios.Where(d => d.idEstatus == 4).First();

            if(inventario <= toxico.rangoSuperior)
            {
                result = new Tuple<int?, decimal?>(5, null);
                return result;
            }
            else if(inventario <= agotado.rangoSuperior)
            {
                result = new Tuple<int?, decimal?>(6, null);
                return result;
            }
            else if(ventaActual < 0)
            {
                result = new Tuple<int?, decimal?>(8, null);
                return result;
            }
            else if(ventaActual <= ventaCero.rangoSuperior)
            {
                result = new Tuple<int?, decimal?>(4, null);
                return result;
            }
            else
            {
                var ventasAnteriores = db.inventarios
                            .Where(d => d.numSemana < idSemana && d.numSemana >= idSemana - 5 && d.idTienda == idTienda && d.idProducto == idProducto && d.cantidadVendida >= 0)
                            .Select(d => d.cantidadVendida)
                            .ToList();

                ventasAnteriores.Add(ventaActual);
                decimal diasInventario = 7 * inventario / (decimal)ventasAnteriores.Average();

                var diasInvCriterios = criterios.Where(d => d.idEstatus <= 3).ToList();
                foreach(var invCriterio in diasInvCriterios)
                {
                    if(diasInventario <= invCriterio.rangoSuperior && diasInventario >= invCriterio.rangoInferior)
                    {
                        result = new Tuple<int?, decimal?>(invCriterio.idEstatus, Math.Round(diasInventario, 3));
                        return result;
                    }
                }

                return new Tuple<int?, decimal?>(null, null);

            }
        }
        public static decimal CalcularDiasInv(int idSemana, int? idProducto, int? idTienda, decimal ventaActual, int idCliente, decimal inventario)
        {
            var ventasAnteriores = db.inventarios
                            .Where(d => d.numSemana < idSemana && d.numSemana >= idSemana - 5 && d.idTienda == idTienda && d.idProducto == idProducto)
                            .Select(d => d.cantidadVendida)
                            .ToList();

            ventasAnteriores.Add(ventaActual);
            decimal diasInventario = 7 * inventario / (decimal)ventasAnteriores.Average();
            diasInventario = Math.Round(diasInventario, 3);
            return diasInventario;

        }
    }
}
