// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: proto/favorites.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

public static partial class FavoriteService
{
  static readonly string __ServiceName = "FavoriteService";

  [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
  static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
  {
    #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
    if (message is global::Google.Protobuf.IBufferMessage)
    {
      context.SetPayloadLength(message.CalculateSize());
      global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
      context.Complete();
      return;
    }
    #endif
    context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
  }

  [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
  static class __Helper_MessageCache<T>
  {
    public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
  }

  [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
  static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
  {
    #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
    if (__Helper_MessageCache<T>.IsBufferMessage)
    {
      return parser.ParseFrom(context.PayloadAsReadOnlySequence());
    }
    #endif
    return parser.ParseFrom(context.PayloadAsNewBuffer());
  }

  [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
  static readonly grpc::Marshaller<global::Favorite> __Marshaller_Favorite = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Favorite.Parser));
  [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
  static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.Empty.Parser));

  [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
  static readonly grpc::Method<global::Favorite, global::Favorite> __Method_getFavorite = new grpc::Method<global::Favorite, global::Favorite>(
      grpc::MethodType.Unary,
      __ServiceName,
      "getFavorite",
      __Marshaller_Favorite,
      __Marshaller_Favorite);

  [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
  static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::Favorite> __Method_getAllFavorites = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::Favorite>(
      grpc::MethodType.ServerStreaming,
      __ServiceName,
      "getAllFavorites",
      __Marshaller_google_protobuf_Empty,
      __Marshaller_Favorite);

  [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
  static readonly grpc::Method<global::Favorite, global::Google.Protobuf.WellKnownTypes.Empty> __Method_addFavorite = new grpc::Method<global::Favorite, global::Google.Protobuf.WellKnownTypes.Empty>(
      grpc::MethodType.Unary,
      __ServiceName,
      "addFavorite",
      __Marshaller_Favorite,
      __Marshaller_google_protobuf_Empty);

  [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
  static readonly grpc::Method<global::Favorite, global::Google.Protobuf.WellKnownTypes.Empty> __Method_deleteFavorite = new grpc::Method<global::Favorite, global::Google.Protobuf.WellKnownTypes.Empty>(
      grpc::MethodType.Unary,
      __ServiceName,
      "deleteFavorite",
      __Marshaller_Favorite,
      __Marshaller_google_protobuf_Empty);

  /// <summary>Service descriptor</summary>
  public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
  {
    get { return global::FavoritesReflection.Descriptor.Services[0]; }
  }

  /// <summary>Client for FavoriteService</summary>
  public partial class FavoriteServiceClient : grpc::ClientBase<FavoriteServiceClient>
  {
    /// <summary>Creates a new client for FavoriteService</summary>
    /// <param name="channel">The channel to use to make remote calls.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public FavoriteServiceClient(grpc::ChannelBase channel) : base(channel)
    {
    }
    /// <summary>Creates a new client for FavoriteService that uses a custom <c>CallInvoker</c>.</summary>
    /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public FavoriteServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
    {
    }
    /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    protected FavoriteServiceClient() : base()
    {
    }
    /// <summary>Protected constructor to allow creation of configured clients.</summary>
    /// <param name="configuration">The client configuration.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    protected FavoriteServiceClient(ClientBaseConfiguration configuration) : base(configuration)
    {
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual global::Favorite getFavorite(global::Favorite request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return getFavorite(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual global::Favorite getFavorite(global::Favorite request, grpc::CallOptions options)
    {
      return CallInvoker.BlockingUnaryCall(__Method_getFavorite, null, options, request);
    }
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual grpc::AsyncUnaryCall<global::Favorite> getFavoriteAsync(global::Favorite request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return getFavoriteAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual grpc::AsyncUnaryCall<global::Favorite> getFavoriteAsync(global::Favorite request, grpc::CallOptions options)
    {
      return CallInvoker.AsyncUnaryCall(__Method_getFavorite, null, options, request);
    }
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual grpc::AsyncServerStreamingCall<global::Favorite> getAllFavorites(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return getAllFavorites(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual grpc::AsyncServerStreamingCall<global::Favorite> getAllFavorites(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::CallOptions options)
    {
      return CallInvoker.AsyncServerStreamingCall(__Method_getAllFavorites, null, options, request);
    }
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual global::Google.Protobuf.WellKnownTypes.Empty addFavorite(global::Favorite request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return addFavorite(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual global::Google.Protobuf.WellKnownTypes.Empty addFavorite(global::Favorite request, grpc::CallOptions options)
    {
      return CallInvoker.BlockingUnaryCall(__Method_addFavorite, null, options, request);
    }
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> addFavoriteAsync(global::Favorite request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return addFavoriteAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> addFavoriteAsync(global::Favorite request, grpc::CallOptions options)
    {
      return CallInvoker.AsyncUnaryCall(__Method_addFavorite, null, options, request);
    }
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual global::Google.Protobuf.WellKnownTypes.Empty deleteFavorite(global::Favorite request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return deleteFavorite(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual global::Google.Protobuf.WellKnownTypes.Empty deleteFavorite(global::Favorite request, grpc::CallOptions options)
    {
      return CallInvoker.BlockingUnaryCall(__Method_deleteFavorite, null, options, request);
    }
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> deleteFavoriteAsync(global::Favorite request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return deleteFavoriteAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> deleteFavoriteAsync(global::Favorite request, grpc::CallOptions options)
    {
      return CallInvoker.AsyncUnaryCall(__Method_deleteFavorite, null, options, request);
    }
    /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    protected override FavoriteServiceClient NewInstance(ClientBaseConfiguration configuration)
    {
      return new FavoriteServiceClient(configuration);
    }
  }

}
#endregion
