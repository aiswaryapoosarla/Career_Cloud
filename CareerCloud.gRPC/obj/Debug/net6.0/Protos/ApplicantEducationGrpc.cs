// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/ApplicantEducation.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace CareerCloud.gRPC {
  public static partial class ApplicantEducation
  {
    static readonly string __ServiceName = "ApplicantEducation.ApplicantEducation";

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
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.IdRequestApplicantEducation> __Marshaller_ApplicantEducation_IdRequestApplicantEducation = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CareerCloud.gRPC.IdRequestApplicantEducation.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.ApplicantEducationReply> __Marshaller_ApplicantEducation_ApplicantEducationReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CareerCloud.gRPC.ApplicantEducationReply.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::CareerCloud.gRPC.IdRequestApplicantEducation, global::CareerCloud.gRPC.ApplicantEducationReply> __Method_GetApplicantEducation = new grpc::Method<global::CareerCloud.gRPC.IdRequestApplicantEducation, global::CareerCloud.gRPC.ApplicantEducationReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetApplicantEducation",
        __Marshaller_ApplicantEducation_IdRequestApplicantEducation,
        __Marshaller_ApplicantEducation_ApplicantEducationReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::CareerCloud.gRPC.ApplicantEducationReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ApplicantEducation</summary>
    [grpc::BindServiceMethod(typeof(ApplicantEducation), "BindService")]
    public abstract partial class ApplicantEducationBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::CareerCloud.gRPC.ApplicantEducationReply> GetApplicantEducation(global::CareerCloud.gRPC.IdRequestApplicantEducation request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(ApplicantEducationBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetApplicantEducation, serviceImpl.GetApplicantEducation).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ApplicantEducationBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetApplicantEducation, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.IdRequestApplicantEducation, global::CareerCloud.gRPC.ApplicantEducationReply>(serviceImpl.GetApplicantEducation));
    }

  }
}
#endregion
