using MigraDoc.DocumentObjectModel;
using System;

namespace PDFsharp_MigraDoc.Exporter.PDFsharp_MigraDoc.BuildingBlocks
{
    public abstract class BuildingBlockBase<DO> where DO : DocumentObject
    {
        public abstract DO DocumentObject { get; }
    }

    public abstract class BuildingBlockBase<DS, DO> : BuildingBlockBase<DO> where DS : class where DO : DocumentObject
    {
        public BuildingBlockBase(DS dataSource)
        {
            DataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
        }

        public DS DataSource { get; }

        public Unit SectionWidth { get; set; } = Unit.Empty;
    }
}
