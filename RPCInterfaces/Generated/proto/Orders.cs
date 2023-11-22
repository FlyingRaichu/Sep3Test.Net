// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: proto/orders.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace proto {

  /// <summary>Holder for reflection information generated from proto/orders.proto</summary>
  public static partial class OrdersReflection {

    #region Descriptor
    /// <summary>File descriptor for proto/orders.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static OrdersReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChJwcm90by9vcmRlcnMucHJvdG8SBXByb3RvGhtnb29nbGUvcHJvdG9idWYv",
            "ZW1wdHkucHJvdG8aHmdvb2dsZS9wcm90b2J1Zi93cmFwcGVycy5wcm90bxoW",
            "cHJvdG8vb3JkZXJJdGVtcy5wcm90bxoVcHJvdG8vYWRkcmVzc2VzLnByb3Rv",
            "GhVwcm90by9mdWxsTmFtZXMucHJvdG8ingEKBU9yZGVyEgoKAmlkGAEgASgF",
            "EhAKCHVzZXJuYW1lGAIgASgJEh8KB2FkZHJlc3MYAyABKAsyDi5wcm90by5B",
            "ZGRyZXNzEiEKCGZ1bGxOYW1lGAQgASgLMg8ucHJvdG8uRnVsbE5hbWUSDQoF",
            "UHJpY2UYBSABKAESJAoKb3JkZXJJdGVtcxgGIAMoCzIQLnByb3RvLk9yZGVy",
            "SXRlbSIhCg1PcmRlclJlc3BvbnNlEhAKCHJlc3BvbnNlGAEgASgJMtwCCgxP",
            "cmRlclNlcnZpY2USNwoIZ2V0T3JkZXISGy5nb29nbGUucHJvdG9idWYuSW50",
            "MzJWYWx1ZRoMLnByb3RvLk9yZGVyIgASOwoPZ2V0T3JkZXJzQnlVc2VyEhYu",
            "Z29vZ2xlLnByb3RvYnVmLkVtcHR5GgwucHJvdG8uT3JkZXIiADABEjYKDGdl",
            "dEFsbE9yZGVycxIWLmdvb2dsZS5wcm90b2J1Zi5FbXB0eRoMLnByb3RvLk9y",
            "ZGVyMAESMAoIYWRkT3JkZXISDC5wcm90by5PcmRlchoULnByb3RvLk9yZGVy",
            "UmVzcG9uc2UiABI1Cgt1cGRhdGVPcmRlchIMLnByb3RvLk9yZGVyGhYuZ29v",
            "Z2xlLnByb3RvYnVmLkVtcHR5IgASNQoLZGVsZXRlT3JkZXISDC5wcm90by5P",
            "cmRlchoWLmdvb2dsZS5wcm90b2J1Zi5FbXB0eSIAQikKEXZpYS5zZXA0LnBy",
            "b3RvYnVmQgpPcmRlclByb3RvUAGqAgVwcm90b2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.WrappersReflection.Descriptor, global::proto.OrderItemsReflection.Descriptor, global::proto.AddressesReflection.Descriptor, global::proto.FullNamesReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::proto.Order), global::proto.Order.Parser, new[]{ "Id", "Username", "Address", "FullName", "Price", "OrderItems" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::proto.OrderResponse), global::proto.OrderResponse.Parser, new[]{ "Response" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Order : pb::IMessage<Order>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<Order> _parser = new pb::MessageParser<Order>(() => new Order());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<Order> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::proto.OrdersReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Order() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Order(Order other) : this() {
      id_ = other.id_;
      username_ = other.username_;
      address_ = other.address_ != null ? other.address_.Clone() : null;
      fullName_ = other.fullName_ != null ? other.fullName_.Clone() : null;
      price_ = other.price_;
      orderItems_ = other.orderItems_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Order Clone() {
      return new Order(this);
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

    /// <summary>Field number for the "username" field.</summary>
    public const int UsernameFieldNumber = 2;
    private string username_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Username {
      get { return username_; }
      set {
        username_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "address" field.</summary>
    public const int AddressFieldNumber = 3;
    private global::proto.Address address_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::proto.Address Address {
      get { return address_; }
      set {
        address_ = value;
      }
    }

    /// <summary>Field number for the "fullName" field.</summary>
    public const int FullNameFieldNumber = 4;
    private global::proto.FullName fullName_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::proto.FullName FullName {
      get { return fullName_; }
      set {
        fullName_ = value;
      }
    }

    /// <summary>Field number for the "Price" field.</summary>
    public const int PriceFieldNumber = 5;
    private double price_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public double Price {
      get { return price_; }
      set {
        price_ = value;
      }
    }

    /// <summary>Field number for the "orderItems" field.</summary>
    public const int OrderItemsFieldNumber = 6;
    private static readonly pb::FieldCodec<global::proto.OrderItem> _repeated_orderItems_codec
        = pb::FieldCodec.ForMessage(50, global::proto.OrderItem.Parser);
    private readonly pbc::RepeatedField<global::proto.OrderItem> orderItems_ = new pbc::RepeatedField<global::proto.OrderItem>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::proto.OrderItem> OrderItems {
      get { return orderItems_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as Order);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(Order other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if (Username != other.Username) return false;
      if (!object.Equals(Address, other.Address)) return false;
      if (!object.Equals(FullName, other.FullName)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Price, other.Price)) return false;
      if(!orderItems_.Equals(other.orderItems_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Id != 0) hash ^= Id.GetHashCode();
      if (Username.Length != 0) hash ^= Username.GetHashCode();
      if (address_ != null) hash ^= Address.GetHashCode();
      if (fullName_ != null) hash ^= FullName.GetHashCode();
      if (Price != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Price);
      hash ^= orderItems_.GetHashCode();
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
      if (Username.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Username);
      }
      if (address_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(Address);
      }
      if (fullName_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(FullName);
      }
      if (Price != 0D) {
        output.WriteRawTag(41);
        output.WriteDouble(Price);
      }
      orderItems_.WriteTo(output, _repeated_orderItems_codec);
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
      if (Username.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Username);
      }
      if (address_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(Address);
      }
      if (fullName_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(FullName);
      }
      if (Price != 0D) {
        output.WriteRawTag(41);
        output.WriteDouble(Price);
      }
      orderItems_.WriteTo(ref output, _repeated_orderItems_codec);
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
      if (Username.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Username);
      }
      if (address_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Address);
      }
      if (fullName_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(FullName);
      }
      if (Price != 0D) {
        size += 1 + 8;
      }
      size += orderItems_.CalculateSize(_repeated_orderItems_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(Order other) {
      if (other == null) {
        return;
      }
      if (other.Id != 0) {
        Id = other.Id;
      }
      if (other.Username.Length != 0) {
        Username = other.Username;
      }
      if (other.address_ != null) {
        if (address_ == null) {
          Address = new global::proto.Address();
        }
        Address.MergeFrom(other.Address);
      }
      if (other.fullName_ != null) {
        if (fullName_ == null) {
          FullName = new global::proto.FullName();
        }
        FullName.MergeFrom(other.FullName);
      }
      if (other.Price != 0D) {
        Price = other.Price;
      }
      orderItems_.Add(other.orderItems_);
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
            Username = input.ReadString();
            break;
          }
          case 26: {
            if (address_ == null) {
              Address = new global::proto.Address();
            }
            input.ReadMessage(Address);
            break;
          }
          case 34: {
            if (fullName_ == null) {
              FullName = new global::proto.FullName();
            }
            input.ReadMessage(FullName);
            break;
          }
          case 41: {
            Price = input.ReadDouble();
            break;
          }
          case 50: {
            orderItems_.AddEntriesFrom(input, _repeated_orderItems_codec);
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
            Username = input.ReadString();
            break;
          }
          case 26: {
            if (address_ == null) {
              Address = new global::proto.Address();
            }
            input.ReadMessage(Address);
            break;
          }
          case 34: {
            if (fullName_ == null) {
              FullName = new global::proto.FullName();
            }
            input.ReadMessage(FullName);
            break;
          }
          case 41: {
            Price = input.ReadDouble();
            break;
          }
          case 50: {
            orderItems_.AddEntriesFrom(ref input, _repeated_orderItems_codec);
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class OrderResponse : pb::IMessage<OrderResponse>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<OrderResponse> _parser = new pb::MessageParser<OrderResponse>(() => new OrderResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<OrderResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::proto.OrdersReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public OrderResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public OrderResponse(OrderResponse other) : this() {
      response_ = other.response_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public OrderResponse Clone() {
      return new OrderResponse(this);
    }

    /// <summary>Field number for the "response" field.</summary>
    public const int ResponseFieldNumber = 1;
    private string response_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Response {
      get { return response_; }
      set {
        response_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as OrderResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(OrderResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Response != other.Response) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Response.Length != 0) hash ^= Response.GetHashCode();
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
      if (Response.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Response);
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
      if (Response.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Response);
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
      if (Response.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Response);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(OrderResponse other) {
      if (other == null) {
        return;
      }
      if (other.Response.Length != 0) {
        Response = other.Response;
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
          case 10: {
            Response = input.ReadString();
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
          case 10: {
            Response = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
