.class public final enum Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;
.super Ljava/lang/Enum;
.source "IGGRealNameVerificationState.java"


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

.field public static final enum IGGRealNameVerificationAuthorized:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

.field public static final enum IGGRealNameVerificationDenied:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

.field public static final enum IGGRealNameVerificationSumbitted:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

.field public static final enum IGGRealNameVerificationUnauthorized:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

.field public static final enum IGGRealNameVerificationUnknow:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;


# instance fields
.field private value:I


# direct methods
.method static constructor <clinit>()V
    .locals 8

    .prologue
    const/4 v7, 0x4

    const/4 v6, 0x3

    const/4 v5, 0x2

    const/4 v4, 0x1

    const/4 v3, 0x0

    .line 10
    new-instance v0, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    const-string v1, "IGGRealNameVerificationSumbitted"

    invoke-direct {v0, v1, v3, v3}, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->IGGRealNameVerificationSumbitted:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    .line 11
    new-instance v0, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    const-string v1, "IGGRealNameVerificationAuthorized"

    invoke-direct {v0, v1, v4, v4}, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->IGGRealNameVerificationAuthorized:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    .line 12
    new-instance v0, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    const-string v1, "IGGRealNameVerificationDenied"

    invoke-direct {v0, v1, v5, v5}, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->IGGRealNameVerificationDenied:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    .line 13
    new-instance v0, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    const-string v1, "IGGRealNameVerificationUnauthorized"

    const/4 v2, -0x1

    invoke-direct {v0, v1, v6, v2}, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->IGGRealNameVerificationUnauthorized:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    .line 14
    new-instance v0, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    const-string v1, "IGGRealNameVerificationUnknow"

    const/4 v2, -0x2

    invoke-direct {v0, v1, v7, v2}, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->IGGRealNameVerificationUnknow:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    .line 9
    const/4 v0, 0x5

    new-array v0, v0, [Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    sget-object v1, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->IGGRealNameVerificationSumbitted:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    aput-object v1, v0, v3

    sget-object v1, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->IGGRealNameVerificationAuthorized:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    aput-object v1, v0, v4

    sget-object v1, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->IGGRealNameVerificationDenied:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    aput-object v1, v0, v5

    sget-object v1, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->IGGRealNameVerificationUnauthorized:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    aput-object v1, v0, v6

    sget-object v1, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->IGGRealNameVerificationUnknow:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    aput-object v1, v0, v7

    sput-object v0, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->$VALUES:[Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;II)V
    .locals 0
    .param p3, "value"    # I
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(I)V"
        }
    .end annotation

    .prologue
    .line 18
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    .line 19
    iput p3, p0, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->value:I

    .line 20
    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;
    .locals 1
    .param p0, "name"    # Ljava/lang/String;

    .prologue
    .line 9
    const-class v0, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object v0

    check-cast v0, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    return-object v0
.end method

.method public static values()[Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;
    .locals 1

    .prologue
    .line 9
    sget-object v0, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->$VALUES:[Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    invoke-virtual {v0}, [Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    return-object v0
.end method
