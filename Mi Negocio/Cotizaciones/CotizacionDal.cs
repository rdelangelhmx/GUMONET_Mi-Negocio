﻿using Mi_Negocio.Datasource;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mi_Negocio.Cotizaciones
{
    class CotizacionDal
    {


        public static int agregar(Cotizacion pData)
        {
            int retorno = 0;
            MySqlConnection conexion = Connection.ObtenerConexion();
            string squery = string.Format("INSERT INTO cotizaciones( folio, id_cliente, fecha, condicion_pago, plazo_entrega, cond_embarque, atn, subtotal, iva, total, status ) "
            + " VALUES ('{0}' ,'{1}' ,'{2}' ,'{3}' ,'{4}' ,'{5}' ,'{6}' ,'{7}' ,'{8}' ,'{9}' ,'{10}')",
                pData.folio
                , pData.id_cliente
                , pData.fecha
                , pData.condicion_pago
                , pData.plazo_entrega
                , pData.cond_embarque
                , pData.atn
                , pData.subtotal
                , pData.iva
                , pData.total
                , pData.status
           );
            MySqlCommand cmd = new MySqlCommand(squery, conexion);
            conexion.Close();
            return retorno;
        }
        public static List<Cotizacion> Buscar(string pSearch = " ")
        {
            List<Cotizacion> _lista = new List<Cotizacion>();
            MySqlConnection conexion = Connection.ObtenerConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format(
                "SELECT id_cotizacion, folio, id_cliente, fecha, condicion_pago, plazo_entrega, cond_embarque, atn, subtotal, iva, total, status from v_cotizaciones where campo_buscar like '%{0}%' ", pSearch), conexion);

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Cotizacion pData = new Cotizacion();
                pData.id_cotizacion = reader.GetInt32(0);
                pData.folio = reader.GetString(1);
                pData.id_cliente = (1);
                pData.fecha = reader.GetDateTime(3);
                pData.condicion_pago = reader.GetString(4);
                pData.plazo_entrega = reader.GetString(5);
                pData.cond_embarque = reader.GetString(6);
                pData.atn = reader.GetString(7);
                pData.subtotal = reader.GetDecimal(8);
                pData.iva = reader.GetDecimal(9);
                pData.total = reader.GetDecimal(10);
                pData.status = reader.GetInt32(11);

                _lista.Add(pData);
            }

            conexion.Close();
            return _lista;
        }

        public static Cotizacion obtener(int pId)
        {
            MySqlConnection conexion = Connection.ObtenerConexion();
            Cotizacion pData = new Cotizacion();

            MySqlCommand cmd = new MySqlCommand(String.Format(
                "select id_cotizacion, nombre  ,encargado  ,razon_social  ,rfc  ,calle  ,n_ext  ,n_int  ,colonia  ,cp  ,localidad  ,municipio  ,estado  ,telefono  ,email where id_cotizacion = {0} ", pId),
                conexion);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                pData.id_cotizacion = reader.GetInt32(0);
                pData.folio = reader.GetString(1);
                pData.id_cliente = (1);
                pData.fecha = reader.GetDateTime(3);
                pData.condicion_pago = reader.GetString(4);
                pData.plazo_entrega = reader.GetString(5);
                pData.cond_embarque = reader.GetString(6);
                pData.atn = reader.GetString(7);
                pData.subtotal = reader.GetDecimal(8);
                pData.iva = reader.GetDecimal(9);
                pData.total = reader.GetDecimal(10);
                pData.status = reader.GetInt32(11);
            }

            conexion.Close();
            return pData;

        }

        public static int actualizar(Cotizacion pData)
        {
            int retorno = 0;
            MySqlConnection conexion = Connection.ObtenerConexion();
            string squery = string.Format("  ",
                 pData.folio
                , pData.id_cliente
                , pData.fecha
                , pData.condicion_pago
                , pData.plazo_entrega
                , pData.cond_embarque
                , pData.atn
                , pData.subtotal
                , pData.iva
                , pData.total
                , pData.status
                , pData.id_cotizacion);
            MySqlCommand cmd = new MySqlCommand(squery, conexion);
            retorno = cmd.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }

        public static int delete(int pIdData)
        {
            int retorno = 0;
            MySqlConnection conexion = Connection.ObtenerConexion();

            MySqlCommand cmd = new MySqlCommand(string.Format("delete from cotizaciones where id_cotizacion = {0}", pIdData), conexion);
            retorno = cmd.ExecuteNonQuery();
            conexion.Close();
            return retorno;

        }
    }
}