.class public Lcom/appsflyer/AFVersionDeclaration;
.super Ljava/lang/Object;
.source ""


# static fields
.field private static googleSdkIdentifier:Ljava/lang/String;


# direct methods
.method private constructor <init>()V
    .locals 0

    .prologue
    .line 8
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static init()V
    .locals 1

    .prologue
    .line 11
    const-string v0, "!SDK-VERSION-STRING!:com.appsflyer:af-android-sdk:4.8.9"

    sput-object v0, Lcom/appsflyer/AFVersionDeclaration;->googleSdkIdentifier:Ljava/lang/String;

    .line 12
    return-void
.end method
