.class public Lcom/igg/util/SignatureUtils;
.super Ljava/lang/Object;
.source "SignatureUtils.java"


# static fields
.field private static final TAG:Ljava/lang/String; = "SignatureUtils"


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 12
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static hamcMD5(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    .locals 10
    .param p0, "data"    # Ljava/lang/String;
    .param p1, "key"    # Ljava/lang/String;

    .prologue
    .line 17
    :try_start_0
    const-string v8, "HmacMD5"

    invoke-static {v8}, Ljavax/crypto/Mac;->getInstance(Ljava/lang/String;)Ljavax/crypto/Mac;

    move-result-object v4

    .line 18
    .local v4, "mac":Ljavax/crypto/Mac;
    new-instance v7, Ljavax/crypto/spec/SecretKeySpec;

    invoke-virtual {p1}, Ljava/lang/String;->getBytes()[B

    move-result-object v8

    invoke-virtual {v4}, Ljavax/crypto/Mac;->getAlgorithm()Ljava/lang/String;

    move-result-object v9

    invoke-direct {v7, v8, v9}, Ljavax/crypto/spec/SecretKeySpec;-><init>([BLjava/lang/String;)V

    .line 19
    .local v7, "sk":Ljavax/crypto/spec/SecretKeySpec;
    invoke-virtual {v4, v7}, Ljavax/crypto/Mac;->init(Ljava/security/Key;)V

    .line 20
    invoke-virtual {p0}, Ljava/lang/String;->getBytes()[B

    move-result-object v8

    invoke-virtual {v4, v8}, Ljavax/crypto/Mac;->doFinal([B)[B

    move-result-object v5

    .line 22
    .local v5, "result":[B
    const-string v6, ""

    .line 23
    .local v6, "ret":Ljava/lang/String;
    new-instance v1, Ljava/lang/StringBuffer;

    invoke-direct {v1}, Ljava/lang/StringBuffer;-><init>()V

    .line 24
    .local v1, "hash":Ljava/lang/StringBuffer;
    const/4 v3, 0x0

    .local v3, "i":I
    :goto_0
    array-length v8, v5

    if-ge v3, v8, :cond_1

    .line 25
    aget-byte v8, v5, v3

    and-int/lit16 v8, v8, 0xff

    invoke-static {v8}, Ljava/lang/Integer;->toHexString(I)Ljava/lang/String;

    move-result-object v2

    .line 26
    .local v2, "hex":Ljava/lang/String;
    invoke-virtual {v2}, Ljava/lang/String;->length()I

    move-result v8

    const/4 v9, 0x1

    if-ne v8, v9, :cond_0

    .line 27
    const/16 v8, 0x30

    invoke-virtual {v1, v8}, Ljava/lang/StringBuffer;->append(C)Ljava/lang/StringBuffer;

    .line 29
    :cond_0
    invoke-virtual {v1, v2}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;

    .line 24
    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    .line 31
    .end local v2    # "hex":Ljava/lang/String;
    :cond_1
    invoke-virtual {v1}, Ljava/lang/StringBuffer;->toString()Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v6

    .line 35
    .end local v1    # "hash":Ljava/lang/StringBuffer;
    .end local v3    # "i":I
    .end local v4    # "mac":Ljavax/crypto/Mac;
    .end local v5    # "result":[B
    .end local v6    # "ret":Ljava/lang/String;
    .end local v7    # "sk":Ljavax/crypto/spec/SecretKeySpec;
    :goto_1
    return-object v6

    .line 33
    :catch_0
    move-exception v0

    .line 34
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    .line 35
    const-string v6, ""

    goto :goto_1
.end method
