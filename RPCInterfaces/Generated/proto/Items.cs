// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: proto/items.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from proto/items.proto</summary>
public static partial class ItemsReflection {

  #region Descriptor
  /// <summary>File descriptor for proto/items.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static ItemsReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "ChFwcm90by9pdGVtcy5wcm90bxobZ29vZ2xlL3Byb3RvYnVmL2VtcHR5LnBy",
          "b3RvGh5nb29nbGUvcHJvdG9idWYvd3JhcHBlcnMucHJvdG8ieAoESXRlbRIK",
          "CgJpZBgBIAEoBRINCgV0aXRsZRgCIAEoCRITCgtkZXNjcmlwdGlvbhgDIAEo",
          "CRINCgVwcmljZRgEIAEoARIUCgxtYW51ZmFjdHVyZXIYBSABKAkSDQoFc3Rv",
          "Y2sYBiABKAUSDAoEdGFncxgHIAMoBTL6AQoLSXRlbVNlcnZpY2USLwoHZ2V0",
          "SXRlbRIbLmdvb2dsZS5wcm90b2J1Zi5JbnQzMlZhbHVlGgUuSXRlbSIAEjAK",
          "C2dldEFsbEl0ZW1zEhYuZ29vZ2xlLnByb3RvYnVmLkVtcHR5GgUuSXRlbSIA",
          "MAESKgoHYWRkSXRlbRIFLkl0ZW0aFi5nb29nbGUucHJvdG9idWYuRW1wdHki",
          "ABItCgp1cGRhdGVJdGVtEgUuSXRlbRoWLmdvb2dsZS5wcm90b2J1Zi5FbXB0",
          "eSIAEi0KCmRlbGV0ZUl0ZW0SBS5JdGVtGhYuZ29vZ2xlLnByb3RvYnVmLkVt",
          "cHR5IgBCIQoRdmlhLnNlcDQucHJvdG9idWZCCkl0ZW1zUHJvdG9QAWIGcHJv",
          "dG8z"));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.WrappersReflection.Descriptor, },
        new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::Item), global::Item.Parser, new[]{ "Id", "Title", "Description", "Price", "Manufacturer", "Stock", "Tags" }, null, null, null, null)
        }));
  }
  #endregion

}
#region Messages
public sealed partial class Item : pb::IMessage<Item>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<Item> _parser = new pb::MessageParser<Item>(() => new Item());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pb::MessageParser<Item> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::ItemsReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public Item() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public Item(Item other) : this() {
    id_ = other.id_;
    title_ = other.title_;
    description_ = other.description_;
    price_ = other.price_;
    manufacturer_ = other.manufacturer_;
    stock_ = other.stock_;
    tags_ = other.tags_.Clone();
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public Item Clone() {
    return new Item(this);
  }

  /// <summary>Field number for the "id" field.</summary>
  public const int IdFieldNumber = 1;
  private int id_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int Id {
    get { return id_; }
    set {
      id_ = value;
    }
  }

  /// <summary>Field number for the "title" field.</summary>
  public const int TitleFieldNumber = 2;
  private string title_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string Title {
    get { return title_; }
    set {
      title_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "description" field.</summary>
  public const int DescriptionFieldNumber = 3;
  private string description_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string Description {
    get { return description_; }
    set {
      description_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "price" field.</summary>
  public const int PriceFieldNumber = 4;
  private double price_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public double Price {
    get { return price_; }
    set {
      price_ = value;
    }
  }

  /// <summary>Field number for the "manufacturer" field.</summary>
  public const int ManufacturerFieldNumber = 5;
  private string manufacturer_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string Manufacturer {
    get { return manufacturer_; }
    set {
      manufacturer_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "stock" field.</summary>
  public const int StockFieldNumber = 6;
  private int stock_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int Stock {
    get { return stock_; }
    set {
      stock_ = value;
    }
  }

  /// <summary>Field number for the "tags" field.</summary>
  public const int TagsFieldNumber = 7;
  private static readonly pb::FieldCodec<int> _repeated_tags_codec
      = pb::FieldCodec.ForInt32(58);
  private readonly pbc::RepeatedField<int> tags_ = new pbc::RepeatedField<int>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public pbc::RepeatedField<int> Tags {
    get { return tags_; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override bool Equals(object other) {
    return Equals(other as Item);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public bool Equals(Item other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Id != other.Id) return false;
    if (Title != other.Title) return false;
    if (Description != other.Description) return false;
    if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Price, other.Price)) return false;
    if (Manufacturer != other.Manufacturer) return false;
    if (Stock != other.Stock) return false;
    if(!tags_.Equals(other.tags_)) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override int GetHashCode() {
    int hash = 1;
    if (Id != 0) hash ^= Id.GetHashCode();
    if (Title.Length != 0) hash ^= Title.GetHashCode();
    if (Description.Length != 0) hash ^= Description.GetHashCode();
    if (Price != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Price);
    if (Manufacturer.Length != 0) hash ^= Manufacturer.GetHashCode();
    if (Stock != 0) hash ^= Stock.GetHashCode();
    hash ^= tags_.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void WriteTo(pb::CodedOutputStream output) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    output.WriteRawMessage(this);
  #else
    if (Id != 0) {
      output.WriteRawTag(8);
      output.WriteInt32(Id);
    }
    if (Title.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(Title);
    }
    if (Description.Length != 0) {
      output.WriteRawTag(26);
      output.WriteString(Description);
    }
    if (Price != 0D) {
      output.WriteRawTag(33);
      output.WriteDouble(Price);
    }
    if (Manufacturer.Length != 0) {
      output.WriteRawTag(42);
      output.WriteString(Manufacturer);
    }
    if (Stock != 0) {
      output.WriteRawTag(48);
      output.WriteInt32(Stock);
    }
    tags_.WriteTo(output, _repeated_tags_codec);
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
    if (Id != 0) {
      output.WriteRawTag(8);
      output.WriteInt32(Id);
    }
    if (Title.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(Title);
    }
    if (Description.Length != 0) {
      output.WriteRawTag(26);
      output.WriteString(Description);
    }
    if (Price != 0D) {
      output.WriteRawTag(33);
      output.WriteDouble(Price);
    }
    if (Manufacturer.Length != 0) {
      output.WriteRawTag(42);
      output.WriteString(Manufacturer);
    }
    if (Stock != 0) {
      output.WriteRawTag(48);
      output.WriteInt32(Stock);
    }
    tags_.WriteTo(ref output, _repeated_tags_codec);
    if (_unknownFields != null) {
      _unknownFields.WriteTo(ref output);
    }
  }
  #endif

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int CalculateSize() {
    int size = 0;
    if (Id != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(Id);
    }
    if (Title.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Title);
    }
    if (Description.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Description);
    }
    if (Price != 0D) {
      size += 1 + 8;
    }
    if (Manufacturer.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Manufacturer);
    }
    if (Stock != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(Stock);
    }
    size += tags_.CalculateSize(_repeated_tags_codec);
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(Item other) {
    if (other == null) {
      return;
    }
    if (other.Id != 0) {
      Id = other.Id;
    }
    if (other.Title.Length != 0) {
      Title = other.Title;
    }
    if (other.Description.Length != 0) {
      Description = other.Description;
    }
    if (other.Price != 0D) {
      Price = other.Price;
    }
    if (other.Manufacturer.Length != 0) {
      Manufacturer = other.Manufacturer;
    }
    if (other.Stock != 0) {
      Stock = other.Stock;
    }
    tags_.Add(other.tags_);
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(pb::CodedInputStream input) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    input.ReadRawMessage(this);
  #else
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 8: {
          Id = input.ReadInt32();
          break;
        }
        case 18: {
          Title = input.ReadString();
          break;
        }
        case 26: {
          Description = input.ReadString();
          break;
        }
        case 33: {
          Price = input.ReadDouble();
          break;
        }
        case 42: {
          Manufacturer = input.ReadString();
          break;
        }
        case 48: {
          Stock = input.ReadInt32();
          break;
        }
        case 58:
        case 56: {
          tags_.AddEntriesFrom(input, _repeated_tags_codec);
          break;
        }
      }
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
          break;
        case 8: {
          Id = input.ReadInt32();
          break;
        }
        case 18: {
          Title = input.ReadString();
          break;
        }
        case 26: {
          Description = input.ReadString();
          break;
        }
        case 33: {
          Price = input.ReadDouble();
          break;
        }
        case 42: {
          Manufacturer = input.ReadString();
          break;
        }
        case 48: {
          Stock = input.ReadInt32();
          break;
        }
        case 58:
        case 56: {
          tags_.AddEntriesFrom(ref input, _repeated_tags_codec);
          break;
        }
      }
    }
  }
  #endif

}

#endregion


#endregion Designer generated code
