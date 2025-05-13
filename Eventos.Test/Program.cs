using System.Linq.Expressions;
using System.Net;
using System.Text;
using Eventos.APIConsumer;
using Eventos.Modelos;
using Newtonsoft.Json;

namespace Eventos.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //RegistrarAsistentes();
            //EliminarAsistentes();
            //UpdateAsistente();
            //RegistrarPonentes();
            //EliminarPonentes();
            //VerAsistentesOPonentes();
            //RegistrarEventos();
            //EliminarEventos();
            //VerEventos();
            //Inscripcion();
            //InscripcionAsistentes();
            //UpdatePonente();
            Pago();
            InscripcionPonentes();
            EspacioAsignado();





        }
       

        //--------------------------------------------------------------------------------------------------------

        private static void RegistrarAsistentes()
        {
            Crud<Asistente>.EndPoint = "https://localhost:7132/api/Asistentes";

            // crear un objeto de la clase asistente
            var asistente = Crud<Asistente>.Create(new Asistente
            {
                Codigo = 0,   // para crear un registro nuevo
                Nombre = "Jordan",
                Apellido = "Salcedo",
                Tipo = "Estudiante",
                
            });
            Console.WriteLine("Asistente Registrado");
            var asistentes = Crud<Asistente>.GetAll();
            foreach (var a in asistentes)
            {
                Console.WriteLine($"Codigo: {a.Codigo}, Nombre: {a.Nombre}, Apellido: {a.Apellido}, Tipo: {a.Tipo}");
            }

        }
        public static void EliminarAsistentes()
        {
            Crud<Asistente>.EndPoint = "https://localhost:7132/api/Asistentes";
            string teclado;

            // Primero, obtenemos todos los asistentes
            var asistentes = Crud<Asistente>.GetAll();

            // Mostramos los asistentes para que el usuario elija
            Console.WriteLine("Seleccione el código del asistente que desea eliminar:");
            foreach (var a in asistentes)
            {
                Console.WriteLine($"Codigo: {a.Codigo}, Nombre: {a.Nombre}, Apellido: {a.Apellido}, Tipo: {a.Tipo}");
            }

            // Leemos la entrada del usuario para obtener el código del asistente a eliminar
            teclado = Console.ReadLine();

            // Asegurarnos de que el valor ingresado sea un número válido
            if (int.TryParse(teclado, out int asistenteId))
            {
                // Usamos GetById para obtener los datos del asistente
                var asistente = Crud<Asistente>.GetById(asistenteId);  // Aquí pasamos el ID correcto

                // Verificamos si el asistente existe
                if (asistente != null)
                {
                    try
                    {
                        // Llamamos al método Delete para eliminarlo
                        Crud<Asistente>.Delete(asistenteId);  // Llamamos a Delete pasando el ID del asistente

                        Console.WriteLine($"Asistente con código {asistenteId} eliminado correctamente.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al eliminar el asistente: {ex.Message}");
                    }
                }
                else
                {
                    // Si no se encuentra al asistente con ese ID
                    Console.WriteLine("Asistente no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID de asistente inválido. Por favor, ingrese un número.");
            }
        }
        public static void UpdateAsistente()
        {
            // Establecer el endpoint para la API de Asistentes
            Crud<Asistente>.EndPoint = "https://localhost:7132/api/Asistentes";

            // Mostrar todos los asistentes disponibles
            var asistentes = Crud<Asistente>.GetAll();
            Console.WriteLine("Lista de Asistentes:");
            foreach (var a in asistentes)
            {
                Console.WriteLine($"Codigo: {a.Codigo}, Nombre: {a.Nombre}, Apellido: {a.Apellido}, Tipo: {a.Tipo}");
            }

            // Pedir al usuario que ingrese el ID del asistente a actualizar
            Console.WriteLine("Ingrese el ID del asistente que desea actualizar:");
            string teclado = Console.ReadLine();

            // Validar que el ID ingresado sea un número válido
            if (int.TryParse(teclado, out int asistenteId))
            {
                // Obtener el asistente con el ID ingresado
                var asistente = Crud<Asistente>.GetById(asistenteId);  // Usamos GetById para obtener los datos del asistente

                if (asistente != null)
                {
                    // Modificar las propiedades que necesitamos actualizar
                    Console.WriteLine("Ingrese el nuevo nombre del asistente:");
                    asistente.Nombre = Console.ReadLine();  // Nuevo nombre del asistente

                    Console.WriteLine("Ingrese el nuevo apellido del asistente:");
                    asistente.Apellido = Console.ReadLine();  // Nuevo apellido del asistente

                    Console.WriteLine("Ingrese el nuevo tipo de asistente:");
                    asistente.Tipo = Console.ReadLine();  // Nuevo tipo del asistente (anteriormente estaba 'Apellido', debería ser 'Tipo')

                    // Llamamos al método Update para enviar los datos actualizados al servidor
                    try
                    {
                        // Enviar la solicitud PUT a la API
                        Crud<Asistente>.Update(asistenteId, asistente);  // Actualiza el asistente
                        Console.WriteLine($"Asistente con ID {asistenteId} actualizado correctamente.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al actualizar el asistente: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Asistente no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID de asistente inválido. Por favor, ingrese un número.");
            }
        }





        //--------------------------------------------------------------------------------------------------------

        private static void RegistrarPonentes()
        {
            Crud<Ponente>.EndPoint = "https://localhost:7132/api/Ponentes";

            // crear un objeto de la clase pais
            var ponente = Crud<Ponente>.Create(new Ponente
            {
                Codigo = 0,   // para crear un registro nuevo
                Nombre = "Diego",
                Apellido = "Trejo",
                Titulo = "Ing.Software",
                
            });
            Console.WriteLine("Ponente Registrado");
            var ponentes = Crud<Ponente>.GetAll();
            foreach (var p in ponentes)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Nombre: {p.Nombre}, Apellido: {p.Apellido}, Titulo: {p.Titulo}");
            }

            // actualizar el pais
            //ponente.Nombre = "Argentina Actualizado";
            //Crud<Ponente>.Update(pais.Codigo, pais);

            // obtener todos los paises
        }
        public static void EliminarPonentes()
        {
            Crud<Ponente>.EndPoint = "https://localhost:7132/api/Ponentes"; 
            string teclado;

            // Primero, obtenemos todos los ponentes
            var ponentes = Crud<Ponente>.GetAll();

            // Mostramos los ponentes para que el usuario elija
            Console.WriteLine("Seleccione el código del ponente que desea eliminar:");
            foreach (var p in ponentes)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Nombre: {p.Nombre}, Apellido: {p.Apellido}, Titulo: {p.Titulo}");
            }

            // Leemos la entrada del usuario para obtener el código del ponente a eliminar
            teclado = Console.ReadLine();

            // Asegurarnos de que el valor ingresado sea un número válido
            if (int.TryParse(teclado, out int ponenteId))
            {
                // Usamos GetById para obtener los datos del ponente
                var ponente = Crud<Ponente>.GetById(ponenteId);  // Aquí pasamos el ID correcto

                // Verificamos si el ponente existe
                if (ponente != null)
                {
                    try
                    {
                        // Llamamos al método Delete para eliminarlo
                        Crud<Ponente>.Delete(ponenteId);  // Llamamos a Delete pasando el ID del ponente

                        Console.WriteLine($"Ponente con código {ponenteId} eliminado correctamente.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al eliminar el ponente: {ex.Message}");
                    }
                }
                else
                {
                    // Si no se encuentra al ponente con ese ID
                    Console.WriteLine("Ponente no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID de ponente inválido. Por favor, ingrese un número.");
            }
        }

        public static void UpdatePonente()
        {
            // Establecer el endpoint para la API de Ponentes
            Crud<Ponente>.EndPoint = "https://localhost:7132/api/Ponentes";  // Corregir a la URL correcta para los ponentes

            // Mostrar todos los ponentes disponibles
            var ponentes = Crud<Ponente>.GetAll();  // Obtener lista de ponentes
            Console.WriteLine("Lista de Ponentes:");
            foreach (var p in ponentes)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Nombre: {p.Nombre}, Apellido: {p.Apellido}, Titulo: {p.Titulo}");
            }

            // Pedir al usuario que ingrese el ID del ponente a actualizar
            Console.WriteLine("Ingrese el ID del ponente que desea actualizar:");
            string teclado = Console.ReadLine();

            // Validar que el ID ingresado sea un número válido
            if (int.TryParse(teclado, out int ponenteId))
            {
                // Obtener el ponente con el ID ingresado
                var ponenteSeleccionado = Crud<Ponente>.GetById(ponenteId);  // Usamos GetById para obtener los datos del ponente

                if (ponenteSeleccionado != null)
                {
                    // Modificar las propiedades que necesitamos actualizar
                    Console.WriteLine("Ingrese el nuevo nombre del ponente:");
                    ponenteSeleccionado.Nombre = Console.ReadLine();  // Nuevo nombre del ponente

                    Console.WriteLine("Ingrese el nuevo apellido del ponente:");
                    ponenteSeleccionado.Apellido = Console.ReadLine();  // Nuevo apellido del ponente

                    Console.WriteLine("Ingrese el nuevo título del ponente:");
                    ponenteSeleccionado.Titulo = Console.ReadLine();  // Nuevo título del ponente

                    // Llamamos al método Update para enviar los datos actualizados al servidor
                    try
                    {
                        // Enviar la solicitud PUT a la API para actualizar
                        Crud<Ponente>.Update(ponenteId, ponenteSeleccionado);  // Actualiza el ponente
                        Console.WriteLine($"Ponente con ID {ponenteId} actualizado correctamente.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al actualizar el ponente: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Ponente no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID de ponente inválido. Por favor, ingrese un número.");
            }
        }

        //----------------------------------------------------------------------------------------------------------
        public static void VerAsistentesYPonentes()
        {
            Crud<Asistente>.EndPoint = "https://localhost:7132/api/Asistentes";
            Crud<Ponente>.EndPoint = "https://localhost:7132/api/Ponentes";
            Console.WriteLine("Asistentes:");
            var asistentes = Crud<Asistente>.GetAll();
            foreach (var a in asistentes)
            {
                Console.WriteLine($"Codigo: {a.Codigo}, Nombre: {a.Nombre}, Apellido: {a.Apellido}, Tipo: {a.Tipo}");
            }
            Console.WriteLine("Ponentes:");
            var ponentes = Crud<Ponente>.GetAll();
            foreach (var p in ponentes)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Nombre: {p.Nombre}, Apellido: {p.Apellido}, Titulo: {p.Titulo}");
            }
        }
        //----------------------------------------------------------------------------------------------------------
        private static void RegistrarEventos()
        {
            Crud<Evento>.EndPoint = "https://localhost:7132/api/Eventos";
            // crear un objeto de la clase autor
            var evento = Crud<Evento>.Create(new Evento
            {
                Codigo = 0,   // para crear un registro nuevo
                Nombre = "Aenit2025 ",
                Fecha = new DateTime(1990, 1, 1),
                Lugar = "Universidad Tecnica Del Norte",
                Tipo = "Conferencias",
            });

            Console.WriteLine($"Evento {evento.Nombre} Registrado");
            var eventos = Crud<Evento>.GetAll();
            foreach (var e in eventos)
            {
                Console.WriteLine($"Codigo: {e.Codigo}, Nombre: {e.Nombre}, Fecha Del Evento: {e.Fecha.ToShortDateString()}, Lugar Del Evento: {e.Lugar}, Tipo De Evento:{e.Tipo} ");
            }
        }
        public static void EliminarEventos()
        {
            Crud<Evento>.EndPoint = "https://localhost:7132/api/Eventos";
            string teclado;

            // Primero, obtenemos todos los ponentes
            var evento = Crud<Evento>.GetAll();

            // Mostramos los ponentes para que el usuario elija
            Console.WriteLine("Seleccione el código del ponente que desea eliminar:");
            foreach (var e in evento)
            {
                Console.WriteLine($"Codigo: {e.Codigo}, Nombre: {e.Nombre}, Fecha Del Evento: {e.Fecha.ToShortDateString()}, Lugar Del Evento: {e.Lugar}, Tipo De Evento:{e.Tipo} ");
            }

            // Leemos la entrada del usuario para obtener el código del ponente a eliminar
            teclado = Console.ReadLine();

            // Asegurarnos de que el valor ingresado sea un número válido
            if (int.TryParse(teclado, out int eventoId))
            {
                // Usamos GetById para obtener los datos del ponente
                var eventos = Crud<Evento>.GetById(eventoId);  // Aquí pasamos el ID correcto

                // Verificamos si el ponente existe
                if (eventos != null)
                {
                    try
                    {
                        // Llamamos al método Delete para eliminarlo
                        Crud<Evento>.Delete(eventoId);  // Llamamos a Delete pasando el ID del ponente

                        Console.WriteLine($"Ponente con código {eventoId} eliminado correctamente.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al eliminar el ponente: {ex.Message}");
                    }
                }
                else
                {
                    // Si no se encuentra al ponente con ese ID
                    Console.WriteLine("Ponente no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID de ponente inválido. Por favor, ingrese un número.");
            }
        }
        public static void VerEventos()
        {
            Crud<Evento>.EndPoint = "https://localhost:7132/api/Eventos";
            
            var evento = Crud<Evento>.GetAll();
            foreach (var e in evento)
            {
                Console.WriteLine($"Codigo: {e.Codigo}, Nombre: {e.Nombre}, Fecha Del Evento: {e.Fecha.ToShortDateString()}, Lugar Del Evento: {e.Lugar}, Tipo De Evento:{e.Tipo} ");
            }

        }
        public static void ActualizarEvento()
        {

        }
        //----------------------------------------------------------------------------------------------------------
        private static void Inscripcion()
        {
            Crud<Inscripcion>.EndPoint = "https://localhost:7132/api/Inscripciones";

            // crear un objeto de la clase editorial
            var inscripcion = Crud<Inscripcion>.Create(new Inscripcion
            {
                Codigo = 0,   // para crear un registro nuevo
                EventoCodigo = 3,
                FechaInicioEvento = new DateTime(1990, 1, 1),
                FechaFinEvento = new DateTime(1990, 1, 1),
            });

            // obtener todas las editoriales
            var inscripcions = Crud<Inscripcion>.GetAll();
            foreach (var i in inscripcions)
            {
                Console.WriteLine($"Codigo: {i.Codigo}, Evento: {i.Evento.Nombre}, Fecha Inicio del Evento: {i.FechaInicioEvento.ToShortDateString()}, Fecha Fin del Evento: {i.FechaFinEvento.ToShortDateString()}");
            }
        }
        private static void InscripcionAsistentes()
        {
            Crud<InscripcionAsistente>.EndPoint = "https://localhost:7132/api/InscripcionesAsistentes";

            // crear un objeto de la clase editorial
            var inscripcion = Crud<InscripcionAsistente>.Create(new InscripcionAsistente
            {
                Codigo = 0,   // para crear un registro nuevo
                AsistenteCodigo = 3,
                InscripcionCodigo = 8,
                FechaInscripcion = new DateTime(1990, 1, 1),
            });

            var inscripciones = Crud<InscripcionAsistente>.GetAll();
            foreach (var ia in inscripciones)
            {
                Console.WriteLine($"Codigo: {ia.Codigo}, Asistente: {ia.Asistente.Nombre}, Fecha De Inscripcion: {ia.FechaInscripcion}, Evento: {ia.Inscripcion.Evento.Nombre},Fecha Inicio del Evento: {ia.Inscripcion.FechaFinEvento.ToShortDateString()}, Fecha Fin del Evento: {ia.Inscripcion.FechaFinEvento.ToShortDateString()}");
            }
        }
        private static void InscripcionPonentes()
        {
            Crud<InscripcionPonente>.EndPoint = "https://localhost:7132/api/InscripcionesPonentes";
            // crear un objeto de la clase autor
            var inscripcionP = Crud<InscripcionPonente>.Create(new InscripcionPonente
            {
                Codigo = 0,   // para crear un registro nuevo
                InscripcionCodigo = 8,
                PonenteCodigo = 3,
                FechaInscripcion = new DateTime(1990, 1, 1),


            });

            // actualizar el autor
            //evento.Nombre = "Juan Actualizado";
            //Crud<InscripcionPonente>.Update(evento.Codigo, evento);

            // obtener todos los autores
            var inscripcionesP = Crud<InscripcionPonente>.GetAll();
            foreach (var ip in inscripcionesP)
            {
                Console.WriteLine($"Codigo: {ip.Codigo}, Asistente: {ip.Inscripcion.Evento.Nombre}, Fecha De Inscripcion: {ip.FechaInscripcion}");
            }
        }
        private static void EspacioAsignado()
        {
            Crud<EspacioAsignado>.EndPoint = "https://localhost:7132/api/EspaciosAsignados";
            // crear un objeto de la clase autor
            var espacio = Crud<EspacioAsignado>.Create(new EspacioAsignado
            {
                Codigo = 0,   // para crear un registro nuevo
                Espacio = "canchas",
                HorarioInicio = new DateTime(1990, 1, 1),
                HorarioFin = new DateTime(1990, 1, 1)

            });

            // actualizar el autor
           // evento.Nombre = "Juan Actualizado";
            //Crud<EspacioAsignado>.Update(evento.Codigo, evento);

            // obtener todos los autores
            var espacios = Crud<EspacioAsignado>.GetAll();
            foreach (var e in espacios)
            {
                Console.WriteLine($"Codigo: {e.Codigo}, Espacios: {e.Espacio}, Horario Inicio: {e.HorarioInicio.ToShortDateString()}, Horaro Fin: {e.HorarioInicio.ToShortDateString()} ");
            }
        }
        private static void EventoLugarAsignado()
        {
            Crud<EventoEnLugarAsignado>.EndPoint = "https://localhost:7132/api/EventosEnLugaresAsignados";
            // crear un objeto de la clase autor
            var eventoAsigando = Crud<EventoEnLugarAsignado>.Create(new EventoEnLugarAsignado
            {
                Codigo = 0,   // para crear un registro nuevo
                EventoCodigo = 0,
                EspacioAsignadoCodigo = 0
            });

            // actualizar el autor
            // evento.Nombre = "Juan Actualizado";
            //Crud<EspacioAsignado>.Update(evento.Codigo, evento);

            // obtener todos los autores
            var eventosAsigando = Crud<EventoEnLugarAsignado>.GetAll();
            foreach (var ea in eventosAsigando)
            {
                Console.WriteLine($"Codigo: {ea.Codigo}, Evento: {ea.Evento.Nombre}, EspacioAsignado: {ea.EspacioAsignado.Espacio},Horario Inico:{ea.EspacioAsignado.HorarioInicio.ToShortDateString()}, Horaro Fin: {ea.EspacioAsignado.HorarioFin.ToShortDateString()}  ");
            }
        }
        private static void PonenteEvento()
        {
            Crud<PonenteEvento>.EndPoint = "https://localhost:7132/api/PonentesEventos";
            // crear un objeto de la clase autor
            var ponenteEvento = Crud<PonenteEvento>.Create(new PonenteEvento
            {
                Codigo = 0,   // para crear un registro nuevo
                EventoCodigo= 0,
                PonenteCodigo = 0,
            });
            
           
            var ponentesEventos = Crud<PonenteEvento>.GetAll();
            foreach (var pe in ponentesEventos)
            {
                Console.WriteLine($"Codigo: {pe.Codigo}, Ponente: {pe.Ponente.Nombre},Evento{pe.Evento.Nombre}");
            }
        }
        private static void Pago()
        {
            Crud<Pago>.EndPoint = "https://localhost:7132/api/Pagos";
            // crear un objeto de la clase autor
            var pago = Crud<Pago>.Create(new Pago
            {
                Codigo = 0,   // para crear un registro nuevo
                InscripcionAsistenteCodigo = 13 ,
                TipoDePago = "transferencia",
                Estado = "pagado",
            });

           
            var pagos = Crud<Pago>.GetAll();
            foreach (var p in pagos)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Asistente: {p.InscripcionAsistente.Asistente.Nombre},Tipo de Pago: {p.TipoDePago}, Estado: {p.Estado}");
            }
        }
        private static void Certificados()
        {
            Crud<Certificado>.EndPoint = "https://localhost:7132/api/Certificados'";
            // crear un objeto de la clase autor
            var certificado = Crud<Certificado>.Create(new Certificado
            {
                Codigo = 0,   // para crear un registro nuevo
                EventoCodigo = 0,
                Tipo = "",
            });

           
            var certificados = Crud<Certificado>.GetAll();
            foreach (var c in certificados)
            {
                Console.WriteLine($"Codigo: {c.Codigo}, Certificado: {c.Eventos.Nombre},Tipo{c.Tipo}");
            }
        }
        private static void CertificadosAsistentes()
        {
            Crud<CertificadoAsistente>.EndPoint = "https://localhost:7132/api/CertificadosAsistentes";
            // crear un objeto de la clase autor
            var certificadoA = Crud<CertificadoAsistente>.Create(new CertificadoAsistente
            {
                Codigo = 0,   // para crear un registro nuevo
                CertificadoCodigo= 0,
                AsistenteCodigo=0,
                Asistencia =""
            });
            
            
            var certificadosA = Crud<CertificadoAsistente>.GetAll();
           
            foreach (var ca in certificadosA)
            {
                Console.WriteLine($"Codigo: {ca.Codigo}, Certificado: {ca.Certificado.Tipo},Nombre Asistente: {ca.Asistente.Nombre}Asistencia {ca.Asistencia}");
            }
        }
        private static void CertificadosPonentes()
        {
            Crud<CertificadoAsistente>.EndPoint = "https://localhost:7132/api/CertificadosPonentes";
            // crear un objeto de la clase autor
            var certificadoP = Crud<CertificadoPonente>.Create(new CertificadoPonente
            {
                Codigo = 0,   // para crear un registro nuevo
                CertificadoCodigo = 0,
                PonenteCodigo = 0,
                
            });

            // actualizar el autor
            //evento.Nombre = "Juan Actualizado";
            //Crud<InscripcionPonente>.Update(evento.Codigo, evento);

            // obtener todos los autores
            var certificadosP = Crud<CertificadoPonente>.GetAll();
            foreach (var ca in certificadosP)
            {
                Console.WriteLine($"Codigo: {ca.Codigo}, Certificado: {ca.Certificado.Tipo},Nombre Ponente: {ca.Ponente.Nombre}");
            }
        }
    }
}