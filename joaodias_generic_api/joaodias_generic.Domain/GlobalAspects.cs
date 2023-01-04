using PostSharp.Extensibility;
using PostSharp.Patterns.Diagnostics;
// This file contains registration of aspects that are applied to several classes of this project.
[assembly: Log(AttributeTargetMemberAttributes = MulticastAttributes.Public, AttributeTargetTypes = "joaodias_generic.*", AttributeTargetTypeAttributes = MulticastAttributes.Public)]