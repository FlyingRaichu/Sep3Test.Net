// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: proto/DiscountCode.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from proto/DiscountCode.proto</summary>
public static partial class DiscountCodeReflection {

  #region Descriptor
  /// <summary>File descriptor for proto/DiscountCode.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static DiscountCodeReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "Chhwcm90by9EaXNjb3VudENvZGUucHJvdG8aG2dvb2dsZS9wcm90b2J1Zi9l",
          "bXB0eS5wcm90bxoeZ29vZ2xlL3Byb3RvYnVmL3dyYXBwZXJzLnByb3RvIkQK",
          "DERpc2NvdW50Q29kZRIKCgJpZBgBIAEoBRIMCgRjb2RlGAIgASgJEhoKEmRp",
          "c2NvdW50UGVyY2VudGFnZRgDIAEoBTKTAgoTRGlzY291bnRDb2RlU2Vydmlj",
          "ZRI/Cg9nZXREaXNjb3VudENvZGUSGy5nb29nbGUucHJvdG9idWYuSW50MzJW",
          "YWx1ZRoNLkRpc2NvdW50Q29kZSIAEkAKE2dldEFsbERpc2NvdW50Q29kZXMS",
          "Fi5nb29nbGUucHJvdG9idWYuRW1wdHkaDS5EaXNjb3VudENvZGUiADABEjoK",
          "D2FkZERpc2NvdW50Q29kZRINLkRpc2NvdW50Q29kZRoWLmdvb2dsZS5wcm90",
          "b2J1Zi5FbXB0eSIAEj0KEmRlbGV0ZURpc2NvdW50Q29kZRINLkRpc2NvdW50",
          "Q29kZRoWLmdvb2dsZS5wcm90b2J1Zi5FbXB0eSIAYgZwcm90bzM="));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.WrappersReflection.Descriptor, },
        new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::DiscountCode), global::DiscountCode.Parser, new[]{ "Id", "Code", "DiscountPercentage" }, null, null, null, null)
        }));
  }
  #endregion

}
#region Messages
public sealed partial class DiscountCode : pb::IMessage<DiscountCode>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<DiscountCode> _parser = new pb::MessageParser<DiscountCode>(() => new DiscountCode());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pb::MessageParser<DiscountCode> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::DiscountCodeReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public DiscountCode() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public DiscountCode(DiscountCode other) : this() {
    id_ = other.id_;
    code_ = other.code_;
    discountPercentage_ = other.discountPercentage_;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public DiscountCode Clone() {
    return new DiscountCode(this);
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

  /// <summary>Field number for the "code" field.</summary>
  public const int CodeFieldNumber = 2;
  private string code_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string Code {
    get { return code_; }
    set {
      code_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "discountPercentage" field.</summary>
  public const int DiscountPercentageFieldNumber = 3;
  private int discountPercentage_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int DiscountPercentage {
    get { return discountPercentage_; }
    set {
      discountPercentage_ = value;
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override bool Equals(object other) {
    return Equals(other as DiscountCode);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public bool Equals(DiscountCode other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Id != other.Id) return false;
    if (Code != other.Code) return false;
    if (DiscountPercentage != other.DiscountPercentage) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override int GetHashCode() {
    int hash = 1;
    if (Id != 0) hash ^= Id.GetHashCode();
    if (Code.Length != 0) hash ^= Code.GetHashCode();
    if (DiscountPercentage != 0) hash ^= DiscountPercentage.GetHashCode();
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
    if (Code.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(Code);
    }
    if (DiscountPercentage != 0) {
      output.WriteRawTag(24);
      output.WriteInt32(DiscountPercentage);
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
    if (Code.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(Code);
    }
    if (DiscountPercentage != 0) {
      output.WriteRawTag(24);
      output.WriteInt32(DiscountPercentage);
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
    if (Code.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Code);
    }
    if (DiscountPercentage != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(DiscountPercentage);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(DiscountCode other) {
    if (other == null) {
      return;
    }
    if (other.Id != 0) {
      Id = other.Id;
    }
    if (other.Code.Length != 0) {
      Code = other.Code;
    }
    if (other.DiscountPercentage != 0) {
      DiscountPercentage = other.DiscountPercentage;
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
        case 18: {
          Code = input.ReadString();
          break;
        }
        case 24: {
          DiscountPercentage = input.ReadInt32();
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
          Code = input.ReadString();
          break;
        }
        case 24: {
          DiscountPercentage = input.ReadInt32();
          break;
        }
      }
    }
  }
  #endif

}

#endregion


#endregion Designer generated code