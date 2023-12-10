// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: proto/orderItems.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from proto/orderItems.proto</summary>
public static partial class OrderItemsReflection {

  #region Descriptor
  /// <summary>File descriptor for proto/orderItems.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static OrderItemsReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "ChZwcm90by9vcmRlckl0ZW1zLnByb3RvGhtnb29nbGUvcHJvdG9idWYvZW1w",
          "dHkucHJvdG8aHmdvb2dsZS9wcm90b2J1Zi93cmFwcGVycy5wcm90byJKCglP",
          "cmRlckl0ZW0SCgoCaWQYASABKAUSDgoGaXRlbUlkGAIgASgFEg8KB29yZGVy",
          "SWQYAyABKAUSEAoIcXVhbnRpdHkYBCABKAUyEgoQT3JkZXJJdGVtU2Vydmlj",
          "ZWIGcHJvdG8z"));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.WrappersReflection.Descriptor, },
        new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::OrderItem), global::OrderItem.Parser, new[]{ "Id", "ItemId", "OrderId", "Quantity" }, null, null, null, null)
        }));
  }
  #endregion

}
#region Messages
public sealed partial class OrderItem : pb::IMessage<OrderItem>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<OrderItem> _parser = new pb::MessageParser<OrderItem>(() => new OrderItem());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pb::MessageParser<OrderItem> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::OrderItemsReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public OrderItem() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public OrderItem(OrderItem other) : this() {
    id_ = other.id_;
    itemId_ = other.itemId_;
    orderId_ = other.orderId_;
    quantity_ = other.quantity_;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public OrderItem Clone() {
    return new OrderItem(this);
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

  /// <summary>Field number for the "itemId" field.</summary>
  public const int ItemIdFieldNumber = 2;
  private int itemId_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int ItemId {
    get { return itemId_; }
    set {
      itemId_ = value;
    }
  }

  /// <summary>Field number for the "orderId" field.</summary>
  public const int OrderIdFieldNumber = 3;
  private int orderId_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int OrderId {
    get { return orderId_; }
    set {
      orderId_ = value;
    }
  }

  /// <summary>Field number for the "quantity" field.</summary>
  public const int QuantityFieldNumber = 4;
  private int quantity_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int Quantity {
    get { return quantity_; }
    set {
      quantity_ = value;
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override bool Equals(object other) {
    return Equals(other as OrderItem);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public bool Equals(OrderItem other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Id != other.Id) return false;
    if (ItemId != other.ItemId) return false;
    if (OrderId != other.OrderId) return false;
    if (Quantity != other.Quantity) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override int GetHashCode() {
    int hash = 1;
    if (Id != 0) hash ^= Id.GetHashCode();
    if (ItemId != 0) hash ^= ItemId.GetHashCode();
    if (OrderId != 0) hash ^= OrderId.GetHashCode();
    if (Quantity != 0) hash ^= Quantity.GetHashCode();
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
    if (ItemId != 0) {
      output.WriteRawTag(16);
      output.WriteInt32(ItemId);
    }
    if (OrderId != 0) {
      output.WriteRawTag(24);
      output.WriteInt32(OrderId);
    }
    if (Quantity != 0) {
      output.WriteRawTag(32);
      output.WriteInt32(Quantity);
    }
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
    if (ItemId != 0) {
      output.WriteRawTag(16);
      output.WriteInt32(ItemId);
    }
    if (OrderId != 0) {
      output.WriteRawTag(24);
      output.WriteInt32(OrderId);
    }
    if (Quantity != 0) {
      output.WriteRawTag(32);
      output.WriteInt32(Quantity);
    }
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
    if (ItemId != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(ItemId);
    }
    if (OrderId != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(OrderId);
    }
    if (Quantity != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(Quantity);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(OrderItem other) {
    if (other == null) {
      return;
    }
    if (other.Id != 0) {
      Id = other.Id;
    }
    if (other.ItemId != 0) {
      ItemId = other.ItemId;
    }
    if (other.OrderId != 0) {
      OrderId = other.OrderId;
    }
    if (other.Quantity != 0) {
      Quantity = other.Quantity;
    }
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
        case 16: {
          ItemId = input.ReadInt32();
          break;
        }
        case 24: {
          OrderId = input.ReadInt32();
          break;
        }
        case 32: {
          Quantity = input.ReadInt32();
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
        case 16: {
          ItemId = input.ReadInt32();
          break;
        }
        case 24: {
          OrderId = input.ReadInt32();
          break;
        }
        case 32: {
          Quantity = input.ReadInt32();
          break;
        }
      }
    }
  }
  #endif

}

#endregion


#endregion Designer generated code
